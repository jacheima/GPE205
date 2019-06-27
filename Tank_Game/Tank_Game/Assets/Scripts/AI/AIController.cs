using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using Vuforia;
using Random = UnityEngine.Random;

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

    public enum AVOID_STATES
    {
        TurnToAvoid, MoveToAvoid
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

    void Seek(Vector3 target)
    {
        data.mover.RotateTowards(target);
        data.mover.Move(target);
    }

    public void TurnToShoot(Transform target)
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        data.mover.RotateToShoot(directionToTarget);
        Debug.Log("Calling Rotate to Shoot");
        
    }

    public void Patrol()
    {
        Vector3 directionToTarget = (currentPatrolPoint.position - transform.position).normalized;
        Seek(directionToTarget);

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 5f)
        {

            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;

            }
            else
            {
                currentPatrolIndex = 0;

            }

            currentPatrolPoint = patrolPoints[currentPatrolIndex];
            
        }

    }

    public void Pursue()
    {
        //if the ai sees a ship they will pursue it until they are in range to attack
        Vector3 directionToTarget = (data.fov.enemyPosition.transform.position - transform.position).normalized;
        Seek(directionToTarget);

    }


    public void ReadyToShoot()
    {
        data.shootRight = false;
        data.shootLeft = false;
        TurnToShoot(data.fov.currentTarget);

    }

    public void Shoot()
    {
        //check if ready to shoot
        if (data.isReadyToShoot == true)
        {
            
           
            if (Time.time > stateStartTime + data.coolDown)
            {
                data.canShootAgian = true;
                data.isInCoolDown = false;

                if (data.isInCoolDown == false)
                {
                    if (data.shootRight)
                    {
                        if (data.canShootAgian)
                        {
                            GameObject bullet = Instantiate(data.cannonball, data.rightCannon.position, data.rightCannon.rotation) as GameObject;
                            cannonBallMover bulletScript = bullet.GetComponent<cannonBallMover>();
                            if (bulletScript != null)
                            {
                                bulletScript.data = data;
                            }
                            data.canShootAgian = false;
                            stateStartTime = Time.time;
                            data.isInCoolDown = true;
                        }

                    }

                    if (data.shootLeft)
                    {
                        if (data.canShootAgian)
                        {
                            GameObject bullet = Instantiate(data.cannonball, data.leftCannon.position, data.leftCannon.rotation) as GameObject;
                            cannonBallMover bulletScript = bullet.GetComponent<cannonBallMover>();
                            if (bulletScript != null)
                            {
                                bulletScript.data = data;
                            }
                            data.canShootAgian = false;
                            stateStartTime = Time.time;
                            data.isInCoolDown = true;
                        }
                    }
                }
            }
        }

        
    }

    public void Search()
    {
        Vector3 directionToTarget = (data.fov.enemyPosition.transform.position - transform.position).normalized;
        Seek(directionToTarget);

     

        
    }

    public void Flee()
    {
        data.mover.Move(transform.forward);

        

        if (Vector3.Distance(data.tf.position, data.fov.currentTarget.position) > data.fov.viewRadius)
        {
            data.health = 3;
        }

        
        
        
    }



}
