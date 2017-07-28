using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyai : MonoBehaviour {

	private health _scripthealth;

	// Use this for initialization
	void Start () {

		_scripthealth = GetComponent<health> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (_scripthealth._health <= 0) {

			Destroy (gameObject);



		}
		
	}


}
