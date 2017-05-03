using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    public float rotacion = 20;
	
	void Start () {
		
	}
	
	void Update () {
        //Sirve para rotar el GameObject
        transform.Rotate(0, 0, rotacion * Time.deltaTime);
		
	}
}
