﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMover : MonoBehaviour
{
    public PawnData data;
    private CharacterController cc;


    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<PawnData>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 directionToMove)
    {
        if(directionToMove == -Vector3.forward)
        {
            
            cc.SimpleMove(directionToMove * data.moveSpeed);
        }
        else
        {
            
            cc.SimpleMove(directionToMove * data.reverseSpeed);
        }



        
    }

    public void Rotate(float directionAndSpeed)
    {
        data.tf.Rotate(new Vector3(0f, directionAndSpeed * data.rotateSpeed * Time.deltaTime, 0f));
    }
}
