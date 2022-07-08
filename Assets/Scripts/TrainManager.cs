using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainManager : MonoBehaviour
{
    public float trainStartPos;  
    public GameObject trainParent,trainTop;
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
        //—ñÔì¬
        TrainSpawn();
        trainMode = Mode.INTRO;
    }    
    void Update()
    {

    }
    /// <summary>
    /// —ñÔ‚ğ¶‚İo‚·
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

}
