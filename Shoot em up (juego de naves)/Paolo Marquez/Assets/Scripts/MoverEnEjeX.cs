using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnEjeX : MonoBehaviour {
    public float speedX = 10;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //convierte la velocidad por frames a velocidad por segundo
        transform.Translate(speedX * Time.deltaTime, 0, 0);

    }
}
