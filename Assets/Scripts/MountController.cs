using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountController : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(-speed*Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Exit"))
        {
            transform.position = new Vector3(25f, transform.position.y, transform.position.z);
        }
    }
}
