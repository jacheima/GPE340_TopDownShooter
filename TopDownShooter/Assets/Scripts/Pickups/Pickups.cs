using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] private float lifespan;
    void Awake()
    {
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            OnPickUp(other.GetComponent<Health>());
        }
        
    }

    protected virtual void OnPickUp(Health player)
    {
        Destroy(gameObject);
    }
}
