using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using Vuforia;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public List<Transform> visibleTargets = new List<Transform>();

    public bool seesEnemy = false;

    public Transform currentTarget;

    public Transform lastSighting;
    public GameObject enemyPosition;


    void Start()
    {
        
    }

    void Update()
    {
        CheckIfVisible();
    }


    void CheckIfVisible()
    {
        visibleTargets.Clear();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, viewRadius, targetMask);


        for (int i = 0; i < hitColliders.Length; i++)
        { 

            Transform target = hitColliders[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, targetMask))
                {
                    if (Vector3.Distance(transform.position, target.position) <= viewRadius)
                    {
                        visibleTargets.Add(target);
                        seesEnemy = true;
                        currentTarget = visibleTargets[0];
                        enemyPosition.transform.position = currentTarget.position;
                        //lastSighting = currentTarget;
                        //lastSighting.position = currentTarget.position;
                    }
                    else
                    {
                        
                        visibleTargets.Remove(currentTarget);
                        //currentTarget = visibleTargets[0];
                        //currentTarget = null;
                        seesEnemy = false;
                    }
                }
            }



        }


    }




    public Vector3 AngleToTarget(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }



}
