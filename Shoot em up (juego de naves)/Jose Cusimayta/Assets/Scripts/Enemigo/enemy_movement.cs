using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour {
    
    public float speedY = 5;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position.y
        if (transform.position.y >= 2.5f)
        {
            speedY = -speedY;
        }
        if (transform.position.y <= -3.5f)
        {
            speedY = -speedY;
        }
        transform.Translate(0, speedY * Time.deltaTime, 0);
    }
}
