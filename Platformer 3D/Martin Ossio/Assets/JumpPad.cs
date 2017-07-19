using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

	public GameObject _victim;

	// Use this for initialization
	void Start () {
		_victim = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter( Collider whoCrashed ) {
		Debug.Log ("Ingrese");
		if (whoCrashed.CompareTag("Player")) {
			Debug.Log ("Es el Player");
			whoCrashed.transform.Translate (0, 2, 0);
			Invoke ("JumpPadGo", 0.01f);
		}
	}

	void JumpPadGo() {
		Debug.Log ("Salte");
		_victim.GetComponent<PlayerControl> ().verticalSpeed = 40;
	}

}
