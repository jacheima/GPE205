using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class PirateAIController : AIController
{
    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case AI_STATES.Patrol:
                Patrol();
                
                if (data.fov.seesEnemy == true)
                {
                    ChangeState(AI_STATES.Pursue);
                }
                break;
            case AI_STATES.Pursue:
                Pursue();

                if (data.fov.seesEnemy == false && data.fov.currentTarget == null)
                {
                        ChangeState(AI_STATES.Patrol);
                }

                if (data.fov.seesEnemy == false && data.fov.currentTarget != null)
                {
                    ChangeState(AI_STATES.Search);
                }

                if (Vector3.Distance(transform.position, data.fov.currentTarget.position) >= data.minRange && Vector3.Distance(transform.position, data.fov.currentTarget.position) <=  data.maxRange)
                {
                    ChangeState(AI_STATES.ReadyToShoot);
                }

                
                break;
            case AI_STATES.ReadyToShoot:
                ReadyToShoot();

                if (data.isReadyToShoot == true)
                {
                    ChangeState(AI_STATES.Shoot);
                }

                if (Vector3.Distance(transform.position, data.fov.enemyPosition.transform.position) < 3f && data.fov.seesEnemy == false)
                {
                    ChangeState(AI_STATES.Patrol);
                }

                if (data.fov.seesEnemy == false && data.fov.lastSighting != null)
                {
                    ChangeState(AI_STATES.Search);
                }

                break;
            case AI_STATES.Shoot:
                data.coolDown = Random.Range(data.coolDownMin, data.coolDownMax);
                Shoot();
                if (data.fov.seesEnemy == false && data.fov.currentTarget == null)
                {
                    ChangeState(AI_STATES.Patrol);
                }

                if (data.fov.seesEnemy == false && data.fov.currentTarget != null)
                {
                    ChangeState(AI_STATES.Search);
                }
                break;
            case AI_STATES.Search:
                Search();
                if (Vector3.Distance(transform.position, data.fov.enemyPosition.transform.position) < 3f && data.fov.seesEnemy == false)
                {
                    ChangeState(AI_STATES.Patrol);
                }

                if (data.fov.seesEnemy == true && data.fov.currentTarget != null)
                {
                    ChangeState(AI_STATES.Pursue);
                }
                break;
            case AI_STATES.Flee:
                Flee();

                if (Time.time > stateStartTime + 5)
                {
                    ChangeState(AI_STATES.Patrol);
                }
                break;
        }
    }
}
