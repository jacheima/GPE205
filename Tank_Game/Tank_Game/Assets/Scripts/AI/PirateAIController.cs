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
                Debug.Log("I am in the patrol state");
                Patrol();

                if (data.fov.seesEnemy == true)
                {
                    ChangeState(AI_STATES.Pursue);
                }
                break;
            case AI_STATES.Pursue:
                Pursue();
                break;
        }
    }
}
