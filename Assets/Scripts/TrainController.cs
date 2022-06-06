using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float speed, trainDownSpeed,trainStopPos;
    MainManager mainManager;
    void Start()
    {
        if (!GameObject.FindGameObjectWithTag("MainManager"))
        {
            return;
        }
        else
        {
            mainManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<MainManager>();
        }        
    }

    void Update()
    {
        //�����ɂ���Ԃ̓�������
        if (!GameManager.Instance.trainStop)     //trainStop�t���O��false�̊Ԃ͗�Ԃ�����
        {
            TrainMove(speed);
        }
        else if(transform.position.x > trainStopPos)
        {
            TrainMove(trainDownSpeed);
        }
        else
        {
            return;
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
}
