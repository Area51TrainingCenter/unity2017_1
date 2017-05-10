using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {

	public Transform _player;
	public float speed = 5;

	// Use this for initialization
	void Start () {

		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		//calculamos el vector entre la bala y el player
		Vector3 direccion = _player.position - transform.position;
		//normalizamos el vector para que su longitud sea 1
		direccion.Normalize ();
		//usamos el objeto 
		transform.Translate (direccion*speed * Time.deltaTime);
	}
}
