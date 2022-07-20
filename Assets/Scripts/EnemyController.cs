using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public float shotBulletTime;
    TrainManager trainManager;
    SoundManager soundManager;
    void Start()
    {
        
    }
    void Update()
    {
        GameObject trainManagerObj = GameObject.FindGameObjectWithTag("TrainManager");
        trainManager =trainManagerObj.GetComponent<TrainManager>();
        GameObject soundManagerObj = GameObject.FindGameObjectWithTag("SoundManager");
        soundManager = soundManagerObj.GetComponent<SoundManager>();
    }
    private void OnBecameVisible()
    {
        if (trainManager.trainMode == TrainManager.Mode.INTRO) return;
        Invoke("ShotBullet", shotBulletTime);
    }
    void ShotBullet()
    {
        Instantiate(bullet, this.transform.position, Quaternion.Euler(0f, 0f, 90f));
        soundManager.Play("shot");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
