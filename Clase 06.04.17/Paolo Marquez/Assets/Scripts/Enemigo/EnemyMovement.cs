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
        if (transform.position.y >= 5.0f)
        {
            speedY = -speedY;

        }


        if (transform.position.y <= -5.0f)
        {
            speedY = -speedY;

        }

        transform.Translate(0, speedY * Time.deltaTime, 0);
    }
}
