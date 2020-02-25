using System.Collections;
using System.Collections.Generic;
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
        OnPickUp(other.GetComponent<PlayerData>());
    }

    protected virtual void OnPickUp(PlayerData player)
    {
        Destroy(gameObject);
    }
}
