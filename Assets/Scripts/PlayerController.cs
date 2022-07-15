using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public GameObject TrainManagerObj,toTitleButton, perfectButton;
    public float jumpPower;
    TrainManager trainManager;
    Rigidbody rd;
    public bool jumpNow,jumpStop;
    [SerializeField]
    private SoundManager soundManager;
    void Start()
    {
        trainManager = TrainManagerObj.GetComponent<TrainManager>();
        rd = GetComponent<Rigidbody>();
        jumpNow = true;
    }
     void Update()
    {
        if(trainManager.trainMode == TrainManager.Mode.INTRO) return;
        if (Input.GetMouseButtonDown(0) && jumpNow == false && jumpStop == false ) 
        {
            jumpNow = true;
            this.rd.AddForce(transform.up * jumpPower);
            soundManager.Play("jump");
        }
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
        if (collision.gameObject.CompareTag("Miss") || collision.gameObject.CompareTag("Bullet"))
        {
            PlayerMiss();
            trainManager.trainMode = TrainManager.Mode.STOP;
        }

    }
    public int dotCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("dot"))
        {
            dotCount++;
            soundManager.Play("dotゲット");
        }
        if (trainManager.allDots != dotCount && other.gameObject.CompareTag("PlayerStop"))
        {
            trainManager.trainMode = TrainManager.Mode.STOP;
            jumpNow = true;
            jumpStop = true;
            Invoke("ToTitle", 1.0f);
        }
        else if(trainManager.allDots == dotCount && other.gameObject.CompareTag("PlayerStop"))
        {
            trainManager.trainMode = TrainManager.Mode.STOP;
            jumpNow = true;
            jumpStop = true;
            perfectButton.SetActive(true);
            soundManager.Play("パーフェクト");
        }
    }
    void ToTitle()
    {
        toTitleButton.SetActive(true);
    }
    public void PlayerMiss()
    {
        jumpNow = true;
        soundManager.Play("Miss");
        this.transform.DOMoveY(5f, 0.3f);
        this.transform.DOMoveZ(-3f, 0.3f).OnComplete(() =>
        {
            this.transform.DOMoveX(-12f, 0.8f);
            soundManager.Play("落下");
            Invoke("PlayerDestroy", 1.5f);
        });
    }
    void PlayerDestroy()
    {
        SceneManager.LoadScene("Main");
        Destroy(gameObject);
    }
}
