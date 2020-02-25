﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HandleMovement(Vector2 movement)
    {
        //set the parameters that controll the animations movement
        anim.SetFloat("Horizontal", movement.x * speed);
        anim.SetFloat("Vertical", movement.y * speed);
    }
}
