using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-bulletSpeed * Time.deltaTime, 0f, 0f);
    }
    private void OnBecameInvisible()
    {
        DoDestroy();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("DoDestroy", 0.1f);
        }
    }
    void DoDestroy()
    {
        Destroy(this.gameObject);
    }
}
