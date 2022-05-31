using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGObjGenerator : MonoBehaviour
{
    public GameObject createPrefab;     //���ݏo���v���t�@�u
    public float cleatePosX, cleatePosY, cleatePosZ;   //���ݏo���v���t�@�u�̈ʒu

    void Start()
    {
        GroundCreate();
    }

    void Update()
    {

    }

    public void GroundCreate()
    {
        GameObject childObject = Instantiate(createPrefab, new Vector3(cleatePosX, cleatePosY, cleatePosZ), Quaternion.identity) as GameObject;
        childObject.transform.parent = this.transform;
    }
}