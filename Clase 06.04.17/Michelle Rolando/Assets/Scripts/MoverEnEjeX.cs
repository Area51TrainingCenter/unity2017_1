using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnEjeX : MonoBehaviour {

    public float speedX = 5f;
    public float speedY = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovimientoContinuo();

    }

    void MovimientoContinuo()
    {
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }
}
