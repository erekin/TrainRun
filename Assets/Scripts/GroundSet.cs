using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSet : MonoBehaviour
{
    [SerializeField]
    GameObject groundPrefab;

    float cleatePosX;

    void Start()
    {
        cleatePosX = 30f;
        GroundCreate();
    }

    void Update()
    {

    }

    public void GroundCreate()
    {
        GameObject childObject = Instantiate(groundPrefab, new Vector3(cleatePosX, 0f, -7f), Quaternion.identity) as GameObject;
        childObject.transform.parent = this.transform;
    }
}

