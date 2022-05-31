using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesController : MonoBehaviour
{
    public float treeSpeed;     //GroundObjの動くスピード
    GameObject treeObj;
    BGObjGenerator bgObjGenerator;

    void Start()
    {
        treeObj = GameObject.FindGameObjectWithTag("TreeSet");
        bgObjGenerator = treeObj.GetComponent<BGObjGenerator>();
    }

    void Update()
    {
        transform.position += new Vector3(-treeSpeed * Time.deltaTime, 0f, 0f);
        if (this.transform.position.x < -30.0f)
        {
            bgObjGenerator.GroundCreate();
            GroundObjBreak();
        }
    }
    public void GroundObjBreak()
    {
        Destroy(this.gameObject);
    }
}
