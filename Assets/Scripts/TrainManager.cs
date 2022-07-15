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
    TrainPrefab trainPrefab;
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
    public int allDots = 0;
    /// <summary>
    /// —ñÔ‚ğ¶‚İo‚·
    /// </summary>
    public void TrainSpawn()
    {
        foreach(GameObject train in trainsArray)
        {
            trains = Instantiate(train, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);

            trainPrefab = train.GetComponent<TrainPrefab>();
            allDots += trainPrefab.dots;      

            trainStartPos += 8.5f;
            trains.transform.parent = trainParent.transform;
        }
        trainParent.transform.position = trainSpawnTrans.position;
    }

}
