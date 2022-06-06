using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float speed, trainDownSpeed,train2ndStopPos;
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
        //条件による列車の動き分岐
        if (!GameManager.Instance.trainStop)     //trainStopフラグがfalseの間は列車が動く
        {
            TrainMove(speed);
        }
        else if(transform.position.x > train2ndStopPos)
        {
            TrainMove(trainDownSpeed);
        }
        else
        {
            return;
        }
    }
    /// <summary>
    /// 列車動く
    /// </summary>
    /// <param name="x"></param>
    public void TrainMove(float x)
    {
        transform.position += new Vector3(x * Time.deltaTime, 0f, 0f);
    }
}
