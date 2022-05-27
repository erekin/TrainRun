using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleManager : MonoBehaviour
{
    public int titleInFr, titleOutFr;
    public float titleCounter , trainRepeatPos;
    public GameObject title , trainPrefab;
    public TextMeshProUGUI counter;

    GameObject trains;
        
    void Start()
    {
        //1個目の列車作成
        TrainSpawn();
    }    
    void Update()
    {　
        //カウンター
        titleCounter = GameManager.Instance.counter;    //毎回 GameManager.Instance.counterと書くの面倒なので変数に入れた
        counter.text = titleCounter.ToString();

        //タイトル表示関連
        if (titleCounter > titleInFr)
        {
            TitleInsert(title);
        }
        /*if(titleCounter > titleOutFr)
        {
            TitleOut(title);
        }*/

        //列車のループ
        if(trains.transform.position.x > trainRepeatPos)
        {
            Destroy(trains.gameObject);
            TrainSpawn();
        }

    }
    /// <summary>
    /// 非表示状態のタイトルを表示状態にする
    /// </summary>
    /// <param name="title"></param>
    public void TitleInsert(GameObject title)
    {
        title.SetActive(true);
    }
    /// <summary>
    /// 表示状態のタイトルを非表示にする（現在使用していません）
    /// </summary>
    /// <param name="title"></param>
    public void TitleOut(GameObject title)
    {
        title.SetActive(false);
    }
    /// <summary>
    /// 列車を生み出す
    /// </summary>
    public void TrainSpawn()
    {
        trains = Instantiate(trainPrefab, new Vector3(-80f, 1f, 0f), Quaternion.identity);
    }
}
