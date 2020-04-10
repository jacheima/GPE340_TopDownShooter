using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//This class takes input and tells the player what to do with it
public class PlayerController : MonoBehaviour
{
    //reference to the pawn class
    [SerializeField] private Pawn pawn;
    //reference to the main camera
    [SerializeField] private Camera main;

    void Start()
    {
        //get the pawn component and set it to pawn
        pawn = GetComponent<Pawn>();
        //find the camera and get the camera component
        main = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        //call the handle movement method in the pawn script
        

        Vector3 movement = new Vector3(0f, 0f, 0f);

        if (Input.GetKey(Game_Manager.instance.keyBindManager.keys["Forward"]))
        {
            movement = Vector3.forward;
        }
        if (Input.GetKey(Game_Manager.instance.keyBindManager.keys["Backward"]))
        {
            movement = -Vector3.forward;
        }

        if (Input.GetKey(Game_Manager.instance.keyBindManager.keys["Left"]))
        {
            movement = -Vector3.right;
        }

        if (Input.GetKey(Game_Manager.instance.keyBindManager.keys["Right"]))
        {
            movement = Vector3.right;
        }

        pawn.HandleMovement(movement);

        //if the player presses the left mouse button
        if (Input.GetButtonDown("Fire1"))
        {
            //call the handle shooting method in pawn script
            pawn.HandleShooting();
        }
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
