using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnData : MonoBehaviour
{
    [Header("Components")]
    public Transform tf;
    public PawnMover mover;

    [Header("Variables")]
    public float moveSpeed = 3.0f;
    public float shotsPerSecond = 1f;
    public float rotateSpeed = 2f;

    [Header("Shooting Info")]
    public GameObject cannonball;
    public Transform frontCannon;
    public Transform leftCannon;
    public Transform rightCannon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
