using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float speed;
    MainManager mainManager;
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<MainManager>();
    }

    void Update()
    {
        if (!mainManager.trainStop)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            return;
        }
    }
}
