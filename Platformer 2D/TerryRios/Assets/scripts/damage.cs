using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour {
	public float Damage = 20;
	public string targettag = "enemigo";

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag(targettag)) 
		{
			other.GetComponent<health> ().ChangeHealth(Damage);
		}
		
	}

}
