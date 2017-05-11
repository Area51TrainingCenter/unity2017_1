using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovement : MonoBehaviour {

    public float movimientoY = 5;
	void Start () {
		
	}
	
	
	void Update () {
        Movimiento();
		
	}
    void Movimiento()
    {

        if (transform.position.y >= 3)
        {
            movimientoY = -movimientoY;
        }
        if (transform.position.y <= -3)
        {
            movimientoY = -movimientoY;
        }
        transform.Translate(0, movimientoY * Time.deltaTime, 0);
    }
}
