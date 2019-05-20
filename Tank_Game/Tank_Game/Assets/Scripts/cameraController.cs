using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public PawnData data;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - data.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = data.transform.position + offset;
    }
}
