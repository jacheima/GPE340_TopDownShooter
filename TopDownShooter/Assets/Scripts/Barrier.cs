using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            this.gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        this.gameObject.GetComponent<Collider>().isTrigger = false;

    }
}
