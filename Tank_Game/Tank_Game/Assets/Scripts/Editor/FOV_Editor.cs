using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FOV_Editor : Editor
{
    void OnSceneGUI()
    {
        // so this is the editor which allows the visaule sites to be seen and edited within unity engine in scripts

        FieldOfView fov = (FieldOfView)target;
        // color of rods and circular range of view is white
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
        Vector3 viewAngleA = fov.DirfromAngle(-fov.viewAngle / 2, false);
        Vector3 viewAngleB = fov.DirfromAngle(fov.viewAngle / 2, false);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);
        // this has the red line which insinuates that it seeing something 
        Handles.color = Color.red;
        foreach (Transform visibleObjects in fov.visibleObjects)
        {
            // looking for objects which the name of the sphere it's spouse to find.
            Handles.DrawLine(fov.transform.position, visibleObjects.position);
        }

    }

}
