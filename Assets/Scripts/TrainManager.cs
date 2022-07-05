using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainManager : MonoBehaviour
{
    public float trainStartPos, playerSpawnTime;  
    public GameObject trainParent,trainTop,player,StartButton;
    public GameObject[] trainsArray;
    public Transform trainSpawnTrans;   //, trainStopTrans
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
        trainMode = Mode.INTRO;
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
    public void OnStartButton()
    {
        trainMode = Mode.MOVE;
        StartButton.SetActive(false);
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
