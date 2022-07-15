using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public float counter;
    //public bool trainStop;
    void Start()
    {
        Application.targetFrameRate = 60;
    }    
    void Update()
    {
        counter = Time.time;
    }
}
