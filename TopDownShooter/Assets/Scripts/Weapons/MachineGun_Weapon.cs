using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//this class is a child class of the weapon base class
public class MachineGun_Weapon : Weapon
{
    //bool to see if the weapon is firing
    private bool isFiring = false;

    //the fire rate of the weapon
    private float fireRate = .25f;

    //the timer
    private float timer;

    protected override void Start()
    {
        //added listeners
        onStartAttack.AddListener(OnStartAttack);
        onEndAttack.AddListener(OnEndAttack);
    }

    //method that overrides the onStartAttack in the base class
    protected override void OnStartAttack()
    {
        base.OnStartAttack();
    }

    //method that overrides the onEndAttack in the base class
    protected override void OnEndAttack()
    {
        base.OnEndAttack();
    }
}