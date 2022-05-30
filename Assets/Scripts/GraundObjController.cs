using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundObjController : MonoBehaviour
{
    public float groundObjSpeed;     //GroundObjの動くスピード
    GameObject groundObj;
    //GroundSet groundSet;
    BGObjGenerator bgObjGenerator;

    void Start()
    {
        groundObj = GameObject.FindGameObjectWithTag("Ground");
        //groundSet = groundObj.GetComponent<GroundSet>();
        bgObjGenerator = groundObj.GetComponent<BGObjGenerator>();
    }

    void Update()
    {
        transform.position += new Vector3(-groundObjSpeed * Time.deltaTime, 0f, 0f);
        if (this.transform.position.x < -12.0f)
        {
            //groundSet.GroundCreate();
            bgObjGenerator.GroundCreate();
            GroundObjBreak();
        }
    }
    public void GroundObjBreak()
    {
        Destroy(this.gameObject);
    }
}
