using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject TrainManagerObj;
    public float jumpPower;
    TrainManager trainManager;
    Rigidbody rd;
    public bool jumpNow;
    void Start()
    {
        trainManager = TrainManagerObj.GetComponent<TrainManager>();
        rd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(trainManager.trainMode == TrainManager.Mode.INTRO) return;
        if (Input.GetMouseButtonDown(0) && jumpNow == false ) 
        {
            Debug.Log("Jump!");
            jumpNow = true;
            //transform.position += transform.up * jumpPower;
            this.rd.AddForce(transform.up * jumpPower);         
        } ;   
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Train"))
        {
            Debug.Log("Tuch");
            jumpNow = false;
        }
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (jumpNow)
        {
            if (collision.gameObject.CompareTag("Train"))
            {
                Debug.Log("Touch");
                jumpNow = false;
            }
        }
    }
}
