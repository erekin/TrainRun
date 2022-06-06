using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    public float trainStartPos,trainStopPos ; 
    public GameObject trainPrefab;

    GameObject trains;
        
    void Start()
    {
        //1個目の列車作成
        TrainSpawn();
    }    
    void Update()
    {
        //列車関連
        TrainStop();
    }
    /// <summary>
    /// 列車を生み出す
    /// </summary>
    public void TrainSpawn()
    {
        trains = Instantiate(trainPrefab, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
    }
    /// <summary>
    /// 列車停止フラグ
    /// </summary>
    public void TrainStop()
    {
        if(trains.transform.position.x > trainStopPos)
        {
            GameManager.Instance.trainStop = true;
        }
        else
        {
            return;
        }
    }
}
