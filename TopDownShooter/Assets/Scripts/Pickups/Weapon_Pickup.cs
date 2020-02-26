using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pickup : Pickups
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private int type;
    protected override void OnPickUp(Player player)
    {
        player.weaponType = type;
        player.EquipWeapon(weapon, type);
        base.OnPickUp(player);
    }
}
