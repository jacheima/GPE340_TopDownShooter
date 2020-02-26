using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MachineGun_Weapon : Weapon
{
    private bool isFiring = false;
    private float fireRate = .25f;
    private float timer;

    protected override void Start()
    {
        onStartAttack.AddListener(OnStartAttack);
        onEndAttack.AddListener(OnEndAttack);
    }

    protected override void OnStartAttack()
    {
        Debug.Log("Start Attack");
        isFiring = true;
        base.OnStartAttack();
    }

    protected override void OnEndAttack()
    {
        Debug.Log("End Attack");
        isFiring = false;
        base.OnEndAttack();
    }

    protected override void Update()
    {
        if(isFiring)
        {
            timer = Time.deltaTime;

            if(timer <= Time.deltaTime + fireRate)
            {
                Fire();
            }

            
        }
    }

    private void Fire()
    {
        //Instatiate bullet & store bullet data in variable
        //set the bullets data as needed
    }
}
