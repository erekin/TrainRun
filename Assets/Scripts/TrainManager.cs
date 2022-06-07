using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainManager : MonoBehaviour
{
    public float trainStartPos, playerSpawnTime;    //train1stStopPos
    public GameObject trainParent,trainTop,player;
    public GameObject[] trainsArray;
    public Transform trainSpawnTrans, trainStopTrans;
    public enum Mode
    {
        INTRO,
        MOVE,
        STOP
    }
    public Mode trainMode;
    GameObject trains;
    
    void Start()
    {
        //��ԍ쐬
        TrainSpawn();
        TrainIntro();
    }    
    void Update()
    {
        //��Ԋ֘A
        //TrainStop();
        //Invoke("PlayerSpawn", playerSpawnTime);
    }
    /// <summary>
    /// ��Ԃ𐶂ݏo��
    /// </summary>
    public void TrainSpawn()
    {
        foreach(GameObject train in trainsArray)
        {
            trains = Instantiate(train, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
            trainStartPos += 8.5f;
            trains.transform.parent = trainParent.transform;
        }
        trainParent.transform.position = trainSpawnTrans.position;
    }
    public void TrainIntro()
    {
        if(trains.transform.position.x > trainStopTrans.transform.position.x) 
        {
            trainMode = Mode.INTRO;
        }
        else
        {
            trainMode = Mode.STOP;
        }
        
    }
    /// <summary>
    /// ��Ԓ�~�t���O
    /// </summary>
    //public void TrainStop()
    //{
    //    if(trains.transform.position.x > train1stStopPos)
    //    {
    //        GameManager.Instance.trainStop = true;
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
    public void PlayerSpawn()
    {
        player.SetActive(true);
    }
}
