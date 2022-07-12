using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public float counter;
    //public bool trainStop;
    void Start()
    {
        //trainStop = false;
    }    
    void Update()
    {
        counter = Time.time;
    }
}
