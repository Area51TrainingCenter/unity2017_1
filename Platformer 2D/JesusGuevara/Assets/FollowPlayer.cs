using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	// persigue al player
	public Transform player;
	public float speed = 5;

	// Use this for initialization
	void Start () {
		// buscamos en la escena el Gameobject que tenga el tag play
		// despues obtenemos el componente Transform de ese gameobject
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (speed);

		// Objeto Destino - objeto inicial
		// calculamos el vector entre la bala y el player
		Vector3 direccion = player.position - transform.position;
		// normalizamos el vector para que su longitud sea 1
		direccion.Normalize ();

		transform.Translate (direccion*speed*Time.deltaTime);

	}
}
