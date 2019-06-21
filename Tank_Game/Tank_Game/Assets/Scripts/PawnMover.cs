using System.Collections;
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
        cc.SimpleMove(directionToMove * data.moveSpeed * Time.deltaTime);
    }

    public void Rotate(float directionAndSpeed)
    {
        data.tf.Rotate(new Vector3(0f, directionAndSpeed * data.rotateSpeed * Time.deltaTime, 0f));
    }


    public void RotateTowards(Vector3 dirToTarget)
    {

        Vector3 targetVector = dirToTarget;
        Quaternion rotateDirection = Quaternion.LookRotation(targetVector, Vector3.up);
        rotateDirection.x = 0;
        rotateDirection.z = 0;
        data.tf.rotation = Quaternion.RotateTowards(data.tf.rotation, rotateDirection, data.rotateSpeed * Time.deltaTime);

    }

    public void RotateToShoot(Vector3 dirToTarget)
    {
        //get vector forward
        Vector3 selfVector = transform.forward;
        //get the vector to the target
        Vector3 targetVector = dirToTarget;
        //calculate angle to target
        //float angleToTarget = Vector3.Angle(selfVector, targetVector);
        float angleToTarget = Vector3.SignedAngle(selfVector, targetVector, Vector3.up);

        Debug.Log(angleToTarget);
        Debug.Log(selfVector);
        Debug.Log(targetVector);


        if (angleToTarget < data.fov.viewAngle/2)
        {
            data.isTurningLeft = true;

            if (!data.isTurningRight)
            {

                transform.Rotate(0f, -1 * data.rotateSpeed * Time.deltaTime, 0f);

                if (angleToTarget >= 80f && angleToTarget <= 100f)
                {
                    data.isReadyToShoot = true;
                    data.isTurningLeft = false;
                    data.shootRight = true;
                }
            }
        }
        else
        {
            data.isTurningRight = true;

            if (!data.isTurningLeft)
            {

                transform.Rotate(0f, -1 * data.rotateSpeed * Time.deltaTime, 0f);

                if (angleToTarget <= -80f && angleToTarget >= -100f)
                {
                    data.isReadyToShoot = true;
                    data.isTurningRight = false;
                    data.shootLeft = true;
                }
            }
        }
        
        


    }
}
