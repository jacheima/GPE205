using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject[] Players;
    public GameObject[] Enemies;


    public void AddDamage(GameObject other)
    {
        other.gameObject.GetComponentInParent<PawnData>().health--;
    }
}
