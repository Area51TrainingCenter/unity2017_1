using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public float damage = 20;
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemigo"))
        {
            other.GetComponent<Health>().health -= damage;
        }
    }
}
