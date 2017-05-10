using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	Transform Player;
	public float velocidad_bolita=5;
	// Use this for initialization
	void Start ()
	{		
		//Player = GameObject.FindGameObjectWithTag ("Player").transform;
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}

	
	// Update is called once per frame
	void Update () {
		PerseguirJugador ();
	}

	void PerseguirJugador(){
		if (Vector3.Distance (Player.position, transform.position) < 10) {
			Vector3 direccion = Player.position - transform.position;
			direccion.Normalize ();
			transform.Translate (direccion * velocidad_bolita * Time.deltaTime);
		}
	}
}