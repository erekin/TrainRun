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
        //1�ڂ̗�ԍ쐬
        TrainSpawn();
    }    
    void Update()
    {
        //��Ԋ֘A
        TrainStop();
    }
    /// <summary>
    /// ��Ԃ𐶂ݏo��
    /// </summary>
    public void TrainSpawn()
    {
        trains = Instantiate(trainPrefab, new Vector3(trainStartPos, 1f, 0f), Quaternion.identity);
    }
    /// <summary>
    /// ��Ԓ�~�t���O
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
