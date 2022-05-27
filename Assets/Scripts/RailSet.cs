using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSet : MonoBehaviour
{
    [SerializeField]
    GameObject railPrefab;

    float cleatePosX;

    void Start()
    {
        cleatePosX = 50f;
        RailCreate();
    }

    void Update()
    {
           
    }

    public void RailCreate()
    {
        GameObject childObject = Instantiate(railPrefab, new Vector3(cleatePosX, 0.75f, 0), Quaternion.identity) as GameObject;
        childObject.transform.parent = this.transform;
    }
}
