using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallMover : MonoBehaviour
{
    private Rigidbody rb;
    public float cannonSpeed = 3.0f;
    public float cannonballDestroy = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * cannonSpeed;
        Destroy(gameObject, cannonballDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
