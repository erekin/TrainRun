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
        //óÒé‘çÏê¨
        TrainSpawn();
        //TrainIntro();
    }    
    void Update()
    {

    }
    /// <summary>
    /// óÒé‘Çê∂Ç›èoÇ∑
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
    /*public void TrainIntro()
    {
        if(trainParent.transform.position.x > trainStopTrans.transform.position.x) 
        {
            trainMode = Mode.INTRO;
        }
        else
        {
            Debug.Log("GO");
            trainMode = Mode.STOP;
        }        
    }*/
    public void PlayerSpawn()
    {
        player.SetActive(true);
    }
}
