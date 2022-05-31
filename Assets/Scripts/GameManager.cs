using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public float counter;
    void Start()
    {
        
    }    
    void Update()
    {
        //counter = Time.frameCount;
        counter = Time.time;
    }
}
