using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

	public float _health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void ChangeHealth (float damage) {

		_health -= damage;


	
		
	}
}
