using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallMover : MonoBehaviour
{
    public PawnData data;
    private Rigidbody rb;
    public float cannonSpeed = 3.0f;
    public float cannonballDestroy = 10.0f;
    public gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * cannonSpeed;
        Destroy(gameObject, cannonballDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject enemy = other.gameObject;
        if (other.gameObject.tag == "Enemy")
        {
            if (data != null)
            {
                if (enemy.GetComponentInParent<PawnData>().health == 1)
                {
                    data.fov.visibleTargets.Remove(other.gameObject.GetComponentInParent<Transform>());
                    data.fov.seesEnemy = false;
                    data.fov.currentTarget = null;
                    Destroy(other.gameObject.transform.parent.gameObject);
                    Destroy(gameObject);
                }
                else
                {
                    enemy.GetComponentInParent<PawnData>().gm.AddDamage(enemy);
                }
                
            }
        }
    }
   
}
