using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour {
	private PlayerControl _playetScript;

	// Use this for initialization
	void Start () {
		_playetScript= GameObject.FindObjectOfType<PlayerControl> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		Debug.Log ("paso");
		if (other.CompareTag("Player")) {
			other.transform.Translate (0, 1, 0);
			Invoke ("SaltoTrampolin", 0.001f);
		}
	}
	void SaltoTrampolin () {
		_playetScript.verticalSpeed = 20;

	}
	void Update () {
		
		
	}
}
