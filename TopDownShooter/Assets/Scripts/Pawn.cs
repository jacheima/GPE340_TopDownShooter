using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private float speed;
    public Animator animation;

    private void Awake()
    {
        animation = GetComponent<Animator>();
    }

    public void HandleMovement(Vector2 movement)
    {
        //set the parameters that controll the animations movement
        animation.SetFloat("Horizontal", movement.x * speed);
        animation.SetFloat("Vertical", movement.y * speed);
    }
}
