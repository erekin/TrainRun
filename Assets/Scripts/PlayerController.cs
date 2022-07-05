using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            jumpNow = true;
            //transform.position += transform.up * jumpPower;
            this.rd.AddForce(transform.up * jumpPower);         
        } ;   
    }
     private void OnCollisionEnter(Collision collision)
    {
        if (jumpNow)
        {
            if (collision.gameObject.CompareTag("Train"))
            {
                jumpNow = false;
            }
        }
        else if (collision.gameObject.CompareTag("Miss"))
        {
            PlayerMiss();
            trainManager.trainMode =TrainManager.Mode.STOP;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerStop"))
        {
            trainManager.trainMode = TrainManager.Mode.STOP;
        }
    }
    public void PlayerMiss()
    {
        jumpNow = true;
        this.transform.DOMoveY(5f, 0.3f);
        this.transform.DOMoveZ(-3f, 0.3f).OnComplete(() =>
        {
            this.transform.DOMoveX(-10f, 0.5f);
            Invoke("PlayerDestroy", 1f);
        });
    }
    void PlayerDestroy()
    {
        Destroy(gameObject);
    }
}
