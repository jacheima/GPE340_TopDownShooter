using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Health_Pickups : Pickups
{
    [SerializeField] private float amount;
    protected override void OnPickUp(Player player)
    {
        player.Heal(amount);
        base.OnPickUp(player);
    }
}
