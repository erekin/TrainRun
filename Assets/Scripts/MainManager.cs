using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    public float trainStartPos,train1stStopPos, playerSpawnTime;
    //public GameObject trainPrefab;
    public GameObject trainParent,player;
    public GameObject[] trainsArray;

    GameObject trains;
        
    void Start()
    {
        //列車作成
        TrainSpawn();
    }    
    void Update()
    {
        //列車関連
        TrainStop();
        Invoke("PlayerSpawn", playerSpawnTime);
    }
    /// <summary>
    /// 列車を生み出す
    /// </summary>
    public void TrainSpawn()
    {
        foreach(GameObject train in trainsArray)
        {
            trains = Instantiate(train, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
            trainStartPos += -8.5f;
            trains.transform.parent = trainParent.transform;
        }
        //trains = Instantiate(trainsArray[i], new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
    }
    /// <summary>
    /// 列車停止フラグ
    /// </summary>
    public void TrainStop()
    {
        if(trains.transform.position.x > train1stStopPos)
        {
            GameManager.Instance.trainStop = true;
        }
        else
        {
            return;
        }
    }
    public void PlayerSpawn()
    {
        player.SetActive(true);
    }
}
