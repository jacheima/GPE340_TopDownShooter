using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//base bullet class
public class Bullet : MonoBehaviour
{
    //how long before the bullet will destroy itself
    [SerializeField] private float lifespan;

    //reference to the rigidbody
    public Rigidbody rb;

    //the amount of damage the bullet will do
    public float damage;

    void Start()
    {
        //set the rigidbody by getting the component on this gameobject
        rb = GetComponent<Rigidbody>();

        //destroy the bullet after the lifespan number of seconds
        Destroy(this.gameObject, lifespan);
    }

    //an method that can be overridden when it collides with another object
    protected virtual void OnCollisionEnter(Collision other)
    {
        //if the gameobject that the bullet collided with has a health component
        if (other.gameObject.GetComponent<Health>())
        {
            //call the TakeDamage method on the Health component on that gameobject
            other.gameObject.GetComponent<Health>().TakeDamage(damage);

            //then destroy the bullet
            Destroy(this.gameObject);
        }
        //if the gameobject doesn't have a health component
        else
        {
            //stop
            return;
        }
        
    }
}
