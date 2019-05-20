using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public PawnData data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Start with the assumption that I am not moving
        Vector3 directionToMove = Vector3.zero;

        //If the W is pressed -- Add "forward to the direction I am moving
        if (Input.GetKey(KeyCode.W))
        {
            directionToMove += -data.tf.forward;
        }

        //If S key is down -- Add "reverse" to the direction I am moving

        if (Input.GetKey(KeyCode.S))
        {
            directionToMove += data.tf.forward;
        }

        //If Up Arrow is pressed -- Shoot a cannon ball from the front of the ship
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Instantiate(data.cannonball, data.frontCannon.position, data.frontCannon.rotation);
        }

        //after i've checked all my inputs, tell my mover to move in the final direction

        data.mover.Move(directionToMove);
    }
}
