using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TrainManager : MonoBehaviour
{
    public float trainStartPos, playerSpawnTime;  
    public GameObject trainParent,trainTop,player,StartButton;
    public GameObject[] trainsArray;
    public Transform trainSpawnTrans;   
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
        //列車作成
        TrainSpawn();
        trainMode = Mode.INTRO;
    }    
    void Update()
    {

    }
    /// <summary>
    /// 列車を生み出す
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
    public void OnToTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
    public void PlayerSpawn()
    {
        player.SetActive(true);
    }
}
