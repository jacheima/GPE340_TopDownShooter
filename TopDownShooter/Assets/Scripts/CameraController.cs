using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float targetRotationSpeed;

    private Camera main;
    private Vector3 offset;

    
    void Start()
    {
        main = GetComponent<Camera>();
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        RotateToMousePosition();
        MoveCameraToTarget();
    }

    private void MoveCameraToTarget()
    {
        transform.position = target.transform.position + offset;
    }

    private void RotateToMousePosition()
    {
        Plane groundPlane;
        groundPlane = new Plane(Vector3.up, target.position);

        float distance;
        Ray ray = main.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out distance))
        {
            Vector3 intersectionPoint = ray.GetPoint(distance);

            target.LookAt(intersectionPoint);
        }
    }
}
