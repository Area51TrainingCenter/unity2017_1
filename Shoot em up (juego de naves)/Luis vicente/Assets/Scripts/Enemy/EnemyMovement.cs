using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speedY = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y >= 0) 
        {
            speedY = -speedY;
        }
        if (transform.position.y <=-2)
        {
            speedY = -speedY;
        }
        transform.Translate(0, speedY * Time.deltaTime, 0);
	}
}
