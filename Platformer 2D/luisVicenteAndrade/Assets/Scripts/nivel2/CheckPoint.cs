using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D other ){
		if (other.CompareTag("Player")) {
			PlayerPrefs.SetFloat ("CheckPointX", transform.position.x);
			PlayerPrefs.SetFloat ("CheckPointY", transform.position.y);
			Destroy (gameObject);
		}
	}
}
