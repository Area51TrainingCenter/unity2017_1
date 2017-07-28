using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {
	public float saludActual=100f;
	public float saludMaxima=100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeHealth(float damage){
		saludActual-=damage;
	}
}
