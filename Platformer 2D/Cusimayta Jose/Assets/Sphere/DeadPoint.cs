﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {
			FollowPlayer followPlayer = GetComponent<FollowPlayer> ();
			followPlayer.velocidad_bolita *= -1;
			//Destroy (other.gameObject);
			//Destroy(gameObject);
		}

	}

}