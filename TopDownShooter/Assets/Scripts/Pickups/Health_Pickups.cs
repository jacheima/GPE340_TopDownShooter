using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

//this is a child class of the pickups class
public class Health_Pickups : Pickups
{
    //the amount of health
    [SerializeField] private float amount;
    
    //this method is on called when the player collides with the pickup
    protected override void OnPickUp(Player player)
    {
        //call the heal method on the player
        player.Heal(amount);
        //call the base method
        base.OnPickUp(player);
    }
}
