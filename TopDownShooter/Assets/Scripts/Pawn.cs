using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pawn : MonoBehaviour
{
    //the speed the player moves at
    [SerializeField] private float speed = 50;
    //reference to the animator
    public Animator anim;

    //reference to the player component
    private Player player;

    private void Awake()
    {
        //set the animator by getting the component
        anim = GetComponent<Animator>();
        //set the player component by getting the player component
        player = GetComponent<Player>();
    }

    //this method handles the movement, by setting the variables in the animator
    public void HandleMovement(Vector2 movement)
    {
        //set the parameters that controls the animations movement
        anim.SetFloat("Horizontal", movement.x * speed);
        anim.SetFloat("Vertical", movement.y * speed);
    }

    //this method handles shooting, by setting the isTriggerPulled to true
    public void HandleShooting()
    {
        //if the player has an weapon equipped
        if (player.equippedWeapon)
        {
            //set isTriggerPulled equal to true
            player.equippedWeapon.isTriggerPulled = true;
        }
    }


}
