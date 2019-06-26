using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject[] Players;
    public GameObject[] Enemies;

    private static gameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddDamage(GameObject other)
    {
        other.gameObject.GetComponentInParent<PawnData>().health--;
    }
}
