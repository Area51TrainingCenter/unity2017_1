using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour {
    public float SpeedY = 10;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y >= 4.5f)
        {
            SpeedY = -SpeedY;
        }

        if (transform.position.y <= -4.5f)
        {
            SpeedY = -SpeedY;
        }

        transform.Translate(0, SpeedY * Time.deltaTime, 0);
    }
}
