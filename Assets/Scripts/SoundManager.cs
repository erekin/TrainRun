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
        public float playTime;  //�O��Đ���������
    }
    [SerializeField]
    private SoundData[] soundDatas;

    //AudioSource�i�X�s�[�J�[�j�𓯎��ɖ炵�������̐������p��
    private AudioSource[] audioSourcesList = new AudioSource[20];

    //�ʖ�(name)���L�[�Ƃ����Ǘ��pDictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    //��x�Đ����Ă���A���Đ��o����܂ł̊Ԋu(�b)
    [SerializeField]
    private float playableDistance = 0.2f;
 
    private void Awake()
    {
        //audioSourceList�z��̐�����AudioSource���������g�ɐ������Ĕz��Ɋi�[
        for(var i = 0; i < audioSourcesList.Length; ++i)
        {
            audioSourcesList[i] = gameObject.AddComponent<AudioSource>();
        }
        //soundDictionary�ɃZ�b�g
        foreach(var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    //���g�p��AudioSource�擾�@���ׂĎg�p���̏ꍇ��null��ԋp
    private AudioSource GetUnusedAudioSource()
    {
        for( var i =0; i < audioSourcesList.Length; ++i)
        {
            if (audioSourcesList[i].isPlaying == false) return audioSourcesList[i];
        }
        return null;//���g�p��AudioSource�͌�����܂���ł���
    }
    //�w�肳�ꂽAudioClip�𖢎g�p��AudioSource�ōĐ�
    public void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //�Đ��ł��܂���ł���
        audioSource.clip = clip;
        audioSource.Play();
    }
    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���Đ�
    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name,out var soundData))//�Ǘ��pDictionary����ʖ��Ō���
        {
            if (Time.realtimeSinceStartup - soundData.playTime < playableDistance) return;    //�܂��Đ�����ɂ͑���
                soundData.playTime = Time.realtimeSinceStartup; //����p�ɍ���̍Đ����Ԃ̕ێ�
            Play(soundData.audioClip);//����������Đ�
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }
}
