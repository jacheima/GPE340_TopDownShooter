using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child class of Pickups
public class Weapon_Pickup : Pickups
{
    //reference to the weapon that will be instantiated after equipping this weapon
    [SerializeField] private Weapon weapon;

    //the number corresponding to the animation type used with this weapon
    // 0 - No Weapon
    // 1 - Rifle
    // 2 - Pistol
    // 3 - ShotGun
    [SerializeField] private int type;

    //override method that adds functionality to the base class OnPickUp method
    protected override void OnPickUp(Player player)
    {
        //set the weapon type in the player class equal to the designer set weapon type int
        player.weaponType = type;

        //call the EquipWeapon method on the player component, passing the Weapon component of the gun you want to equip and the type 
        player.EquipWeapon(weapon, type);

        //execute the base class OnPickUp method
        base.OnPickUp(player);
    }
}
