using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class cameraController : MonoBehaviour
{

    public PawnData data;
    private Vector3 offset;
    private Transform tf;


    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        offset = tf.position - data.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        tf.position = data.transform.position + offset;
        tf.LookAt(data.target);
        
    }
}
