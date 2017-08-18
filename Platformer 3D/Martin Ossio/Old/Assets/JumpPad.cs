using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
	public float jumpForce = 20;
	private GameObject _victim;

	// Use this for initialization
	void Start () {
		_victim = GameObject.FindGameObjectWithTag ("Player");
	}
		
	void OnTriggerEnter( Collider whoCrashed ) {
		if (whoCrashed.CompareTag("Player")) {
			whoCrashed.transform.Translate (0, 2, 0);
			Invoke ("JumpPadGo", 0.01f);
		}
	}

	void JumpPadGo() {
		_victim.GetComponent<PlayerControl> ().verticalSpeed = jumpForce;
	}

}
