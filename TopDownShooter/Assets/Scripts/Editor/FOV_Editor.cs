using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Pawn))]
public class FOV_Editor : Editor
{
    void OnSceneGUI()
    {
        Debug.Log("Called Editor Script");
        Pawn fov = (Pawn) target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        Handles.color = Color.white;
        Vector3 viewAngle_A = fov.AngleToTarget(-fov.viewAngle / 2, false);
        Vector3 viewAngle_B = fov.AngleToTarget(fov.viewAngle / 2, false);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle_A * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle_B * fov.viewRadius);
    }
}
