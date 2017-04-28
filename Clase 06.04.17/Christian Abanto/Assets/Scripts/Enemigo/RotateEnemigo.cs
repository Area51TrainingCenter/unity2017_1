using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemigo : MonoBehaviour {

    public int velocidadRotar = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, velocidadRotar * Time.deltaTime);
	}
}
