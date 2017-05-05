using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour {
    public float speedy = 5;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speedy * Time.deltaTime, 0);
        if (transform.position.y <= 4.3f)
        {
            speedy = -speedy;
        }
        if (transform.position.y >= -4.3f)
        {
            speedy = -speedy;
        }
    }
}
