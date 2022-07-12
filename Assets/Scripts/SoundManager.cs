using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip audioClip;
        public float playTime;  //前回再生した時間
    }
    [SerializeField]
    private SoundData[] soundDatas;

    //AudioSource（スピーカー）を同時に鳴らしたい音の数だけ用意
    private AudioSource[] audioSourcesList = new AudioSource[20];

    //別名(name)をキーとした管理用Dictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    //一度再生してから、次再生出来るまでの間隔(秒)
    [SerializeField]
    private float playableDistance = 0.2f;
 
    private void Awake()
    {
        //audioSourceList配列の数だけAudioSourceを自分自身に生成して配列に格納
        for(var i = 0; i < audioSourcesList.Length; ++i)
        {
            audioSourcesList[i] = gameObject.AddComponent<AudioSource>();
        }
        //soundDictionaryにセット
        foreach(var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    //未使用のAudioSource取得　すべて使用中の場合はnullを返却
    private AudioSource GetUnusedAudioSource()
    {
        for( var i =0; i < audioSourcesList.Length; ++i)
        {
            if (audioSourcesList[i].isPlaying == false) return audioSourcesList[i];
        }
        return null;//未使用のAudioSourceは見つかりませんでした
    }
    //指定されたAudioClipを未使用のAudioSourceで再生
    public void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //再生できませんでした
        audioSource.clip = clip;
        audioSource.Play();
    }
    //指定された別名で登録されたAudioClipを再生
    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name,out var soundData))//管理用Dictionaryから別名で検索
        {
            if (Time.realtimeSinceStartup - soundData.playTime < playableDistance) return;    //まだ再生するには早い
                soundData.playTime = Time.realtimeSinceStartup; //次回用に今回の再生時間の保持
            Play(soundData.audioClip);//見つかったら再生
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }
}
