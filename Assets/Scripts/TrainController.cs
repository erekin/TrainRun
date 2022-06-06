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
        //ðŒ‚É‚æ‚é—ñŽÔ‚Ì“®‚«•ªŠò
        if (!GameManager.Instance.trainStop)     //trainStopƒtƒ‰ƒO‚ªfalse‚ÌŠÔ‚Í—ñŽÔ‚ª“®‚­
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
    /// —ñŽÔ“®‚­
    /// </summary>
    /// <param name="x"></param>
    public void TrainMove(float x)
    {
        transform.position += new Vector3(x * Time.deltaTime, 0f, 0f);
    }
}
