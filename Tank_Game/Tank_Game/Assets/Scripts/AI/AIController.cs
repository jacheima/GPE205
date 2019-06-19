using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Components")]
    public PawnData data;

    public enum AI_STATES
    {
        Patrol, Search, Attack, Chase, Flee
    }

    public List<Transform> waypoints;
    public int currentWaypoint;
    public float closeEnough;
    public float stateStartTime;
    public AI_STATES currentState;
    public float raycastDistance;

    public void ChangeStates(AI_STATES newState)
    {
        stateStartTime = Time.time;
        currentState = newState;
    }

    public void Search()
    {

    }


}
