using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Pawn pawn;
    [SerializeField] private Camera main;

    void Start()
    {
        pawn = GetComponent<Pawn>();
        main = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        pawn.HandleMovement(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        ////for running
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    pawn.animation.SetBool("isWalking", false);
        //}
        //else
        //{
        //    pawn.animation.SetBool("isWalking", true);
        //}

        ////for crouching
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    pawn.animation.SetBool("isCrouching", true);
        //}
        //else
        //{
        //    pawn.animation.SetBool("isCrouching", false);
        //}
    }
}
