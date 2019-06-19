using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    // this is the range
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public LayerMask targetsMask;
    public LayerMask obstaclesMask;

    

    public List<Transform> visibleObjects = new List<Transform>();



    //last place I was at.
    void Start()
    {
        
    }

    void Update()
    {
        visibleObjects.Clear();
        Collider[] objectsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetsMask);
        for (int i = 0; i < objectsInViewRadius.Length; i++)
        {
            
            Debug.Log("I got this far 1");
            Transform objects = objectsInViewRadius[i].transform;
            visibleObjects.Add(objects);
            Vector3 dirToObjects = (objects.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToObjects) < viewAngle / 2)
            {
                float dstToObjects = Vector3.Distance(transform.position, objects.position);

                RaycastHit[] myhits = Physics.RaycastAll(transform.position, dirToObjects, dstToObjects);
                Debug.DrawLine(transform.position, dirToObjects*viewRadius, Color.red);

                for (int j = 0; j < myhits.Length; j++)
                {
                    Debug.Log("I got this far 2");
                    if (myhits[j].transform.GetComponent<Enemy>() != null || myhits[j].transform.GetComponent<PawnData>() != null)
                    {

                        visibleObjects.Add(objects);
                    }
                }
                
            }
        }
    }
    

    public Vector3 DirfromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            //angle of degrees
            angleInDegrees += transform.eulerAngles.y;
            //(note unity always has 0 on top and clockwise till sin (90-X) = cos (X) )
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
