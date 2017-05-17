using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {
	public string targetTag;
	// Use this for initialization
	void Start () {
		
	}
	

	void OnTriggerEnter (Collider other) 
	{
		if (other.CompareTag(targetTag)) 
		{
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
