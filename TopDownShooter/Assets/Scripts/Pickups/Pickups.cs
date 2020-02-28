using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

//The pickups base class
public class Pickups : MonoBehaviour
{
    //the lifespan of the pickups
    [SerializeField] private float lifespan;
    void Awake()
    {
        //destroy the gameobject after set time period
        Destroy(gameObject, lifespan);
    }

    //when something collides with the pickup
    void OnTriggerEnter(Collider other)
    {
        //if the thing that collided with the pickup
        if (other.GetComponent<PlayerController>())
        {
            //call the onPickUp method and pass the player to it
            OnPickUp(other.GetComponent<Player>());
        }
        
    }

    protected virtual void OnPickUp(Player player)
    {
        Destroy(gameObject);
    }
}
