using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class controls the camera and player rotation
public class CameraController : MonoBehaviour
{
    //reference to the target that the camera will follow
    [SerializeField] private Transform target;

    //reference to the main camera
    private Camera main;
    //the offset that the camera will follow at
    private Vector3 offset;

    
    void Start()
    {
        //set the main camera by getting the camera component
        main = GetComponent<Camera>();
        
        //set the target by finding the player gameobject in the world and get its transform
        target = GameObject.Find("Player").GetComponent<Transform>();

        //set the offset by subtracting the target position from the actual position of the camera
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        //call the rotate to mouse position method
        RotateToMousePosition();
        //cal the move camera to target method
        MoveCameraToTarget();
    }

    //this method moves the camera to the target
    private void MoveCameraToTarget()
    {
        //set the camera transform to the target position plus the offset
        transform.position = target.transform.position + offset;
    }

    //this method rotates the player toward the mouse position
    private void RotateToMousePosition()
    {
        //establish a plane called ground plane
        Plane groundPlane;
        //set ground plane to a new ground plane
        groundPlane = new Plane(Vector3.up, target.position);

        //declare a local variable for the distance
        float distance;
        //create a ray that starts at the mouse position
        Ray ray = main.ScreenPointToRay(Input.mousePosition);

        //raycast 
        if (groundPlane.Raycast(ray, out distance) && !Game_Manager.instance.pausedGame)
        {
            //save the point into a vector 3
            Vector3 intersectionPoint = ray.GetPoint(distance);

            //rotate the player to look at the intersection point
            target.LookAt(intersectionPoint);
        }

        if(groundPlane.Raycast(ray, out distance) && Game_Manager.instance.pausedGame)
        {
            
        }
    }
}
