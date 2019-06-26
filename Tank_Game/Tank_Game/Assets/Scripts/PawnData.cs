using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnData : MonoBehaviour
{
    public gameManager gm;
    [Header("Components")]
    public Transform tf;
    public PawnMover mover;
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
    public bool canShootAgian = false;
    public float maxRange = 300f;
    public float minRange = 50;
    public float coolDown;
    public float coolDownMin = 2f;
    public float coolDownMax = 6f;

    [Header("AI Bools")]
    public bool isReadyToShoot = false;
    public bool isTurningLeft = false;
    public bool isTurningRight = false;
    public bool shootRight = false;
    public bool shootLeft = false;
    public bool isInCoolDown = false;

    [Header(("Pirate AI Stats"))]
    public int health = 4;

}
