using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailController : MonoBehaviour
{
    public float railSpeed;     //線路の動くスピード
    GameObject railSeObjt;
    //RailSet railSet;
    BGObjGenerator bgObjGenerator;

    void Start()
    {
        railSeObjt = GameObject.FindGameObjectWithTag("RailSet");
        //railSet = railSeObjt.GetComponent<RailSet>();
        bgObjGenerator = railSeObjt.GetComponent<BGObjGenerator>();
    }

    void Update()
    {
        transform.position += new Vector3(-railSpeed * Time.deltaTime, 0f, 0f);
        if(this.transform.position.x < -50.0f)
        {
            //railSet.RailCreate();
            bgObjGenerator.GroundCreate();
            RailBreak();
        }
    }
    public void RailBreak()
    {
        Destroy(this.gameObject);
    }
}
