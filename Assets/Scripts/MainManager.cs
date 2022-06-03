using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    public float mainCounter ,trainStartPos,trainEndPos ; 
    public GameObject trainPrefab;
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
        mainCounter = GameManager.Instance.counter;    //毎回 GameManager.Instance.counterと書くの面倒なので変数に入れた
        counter.text = mainCounter.ToString();

        //列車のループ
        if(trains.transform.position.x > trainEndPos)
        {
            trains.transform.position = new Vector3(trainStartPos, trains.transform.position.y, trains.transform.position.z);
        }

    }
    /// <summary>
    /// 列車を生み出す
    /// </summary>
    public void TrainSpawn()
    {
        trains = Instantiate(trainPrefab, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
    }
}
