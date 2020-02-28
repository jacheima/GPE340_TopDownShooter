using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    //when the player collides with the damage item
    void OnTriggerEnter(Collider other)
    {
        //check to see if it is the player
        if (other.gameObject.GetComponent<Player>())
        {
            //apply 10 damage
            other.gameObject.GetComponent<Health>().TakeDamage(10);
        }
    }
}
