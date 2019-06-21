using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("General")]
    public PawnData data;

    //for AI patrolling
    [Header("Patrolling")]
    public Transform[] patrolPoints;
    public Transform currentPatrolPoint;
    public int currentPatrolIndex = 0;
    public AI_STATES currentState;
    public float stateStartTime;

    

    public enum AI_STATES
    {
        Patrol, Search, Pursue, ReadyToShoot, Shoot, Flee
    }

    void Awake()
    {
        currentPatrolIndex = 0;
        Debug.Log(patrolPoints.Length);
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        Debug.Log(currentPatrolPoint);
    }

    public void ChangeState(AI_STATES newState)
    {
        stateStartTime = Time.time;
        currentState = newState;
    }

    void Seek(Transform target)
    {
        Debug.Log("Seeking");
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        data.mover.RotateTowards(directionToTarget);
        data.mover.Move(directionToTarget);
    }

    public void TurnToShoot(Transform target)
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        data.mover.RotateToShoot(directionToTarget);
        Debug.Log("Calling Rotate to Shoot");
        
    }

    public void Patrol()
    {
        Debug.Log("I was called from the switch statement");
        Seek(currentPatrolPoint);

        
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 5f)
        {
            Debug.Log("I'm close to the waypoint");
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
                Debug.Log("I am incrementing the waypoint index");
            }
            else
            {
                currentPatrolIndex = 0;
                Debug.Log("I am setting the waypoint back to zero");
            }

            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
    }

    public void Pursue()
    {
        //if the ai sees a ship they will pursue it until they are in range to attack
        Seek(data.fov.currentTarget);

    }


    public void ReadyToShoot()
    {
        data.shootRight = false;
        data.shootLeft = false;
        TurnToShoot(data.fov.currentTarget);
    }

    public void Shoot()
    {
        
    }




}
