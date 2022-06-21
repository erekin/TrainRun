using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float speed, introSpeed,DownSpeed;  //,train2ndStopPos
    TrainManager trainManager;
    void Start()
    {
        if (!GameObject.FindGameObjectWithTag("MainManager"))
        {
            return;
        }
        else
        {
            trainManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<TrainManager>();
        }        
    }
    void Update()
    {
        //�����ɂ���Ԃ̓�������
        switch (trainManager.trainMode)
        {
            case TrainManager.Mode.INTRO:
                TrainMove(introSpeed);
                break;
            case TrainManager.Mode.MOVE:
                TrainMove(speed);
                break;
            case TrainManager.Mode.STOP:
                TrainMove(0f);
                break;
        }
    }
    /// <summary>
    /// ��ԓ���
    /// </summary>
    /// <param name="x"></param>
    public void TrainMove(float x)
    {
        transform.position += new Vector3(x * Time.deltaTime, 0f, 0f);
    }
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrainStop"))
        {
            trainManager.trainMode = TrainManager.Mode.STOP;
        }
    }*/
}
