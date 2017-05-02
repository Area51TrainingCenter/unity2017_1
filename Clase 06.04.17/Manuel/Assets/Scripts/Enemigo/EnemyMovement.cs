using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speedy = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //tranform.position.y
        if (transform.position.y >= 2.5f)
        {
            speedy = -speedy;
        }
        if (transform.position.y <= -3.5f)
        {
            speedy = -speedy;
        }
        transform.Translate(0, speedy * Time.deltaTime, 0);
    }
}
