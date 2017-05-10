using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		//calculamos el vector entre la bala y el player
		//Destino - posición de origen
		Vector3 direccion = player.position - transform.position;
		//normalizamos el vector para que su longitud sea 1
		direccion.Normalize ();
		transform.Translate (direccion * Time.deltaTime);
	}
}
