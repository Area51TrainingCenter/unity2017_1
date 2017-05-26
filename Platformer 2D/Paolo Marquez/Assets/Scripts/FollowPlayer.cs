using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform player;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		//buscamos en la escena el GameObject que tenga el tag player
		//despues obtenemos el componente Transform de ese GameObject
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		//calculamos el vector entre la bala y el player
		Vector3 direccion = player.position - transform.position;

		//normalizamos el vector para que su longitud sea 1
		direccion.Normalize ();

		//movemos el objeto usando el vector
		transform.Translate (direccion * speed * Time.deltaTime);
	}
}
