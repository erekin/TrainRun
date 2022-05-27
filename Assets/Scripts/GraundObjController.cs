using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundObjController : MonoBehaviour
{
    public float groundObjlSpeed;     //GroundObjの動くスピード
    GameObject groundObj;
    GroundSet groundSet;

    void Start()
    {
        groundObj = GameObject.FindGameObjectWithTag("Ground");
        groundSet = groundObj.GetComponent<GroundSet>();
    }

    void Update()
    {
        transform.position += new Vector3(-groundObjlSpeed * Time.deltaTime, 0f, 0f);
        if (this.transform.position.x < -12.0f)
        {
            groundSet.GroundCreate();
            GroundObjBreak();
        }
    }
    public void GroundObjBreak()
    {
        Destroy(this.gameObject);
    }
}
