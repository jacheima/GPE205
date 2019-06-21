using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnData : MonoBehaviour
{
    [Header("Components")]
    public Transform tf;
    public PawnMover mover;
    public Transform target;
    public FieldOfView fov;

    [Header("Movement")]
    public float moveSpeed = 3.0f;
    public float reverseSpeed = 1.0f;

    public float rotateSpeed = 2f;

    [Header("Shooting Info")]
    public cannonBallMover cbm;
    public GameObject cannonball;
    public Transform frontCannon;
    public Transform leftCannon;
    public Transform rightCannon;
    public int maxCannonRange;
    public bool canShootAgian = false;
    public float shotsPerSecond = 1f;
    public float cannonTimer = 1;

    [Header("AI Bools")]
    public bool isReadyToShoot = false;
    public bool isTurningLeft = false;
    public bool isTurningRight = false;
    public bool shootRight = false;
    public bool shootLeft = false;


}
