using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGObjGenerator : MonoBehaviour
{
    public GameObject createPrefab;     //生み出すプレファブ
    public float cleatePosX, cleatePosY, cleatePosZ;   //生み出すプレファブの位置

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