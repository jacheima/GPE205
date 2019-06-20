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
}
