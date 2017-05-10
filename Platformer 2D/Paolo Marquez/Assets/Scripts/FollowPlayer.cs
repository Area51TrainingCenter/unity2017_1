using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform player;
	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		//buscamos en la escena el GameObject que tenga el tag player
		player=GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//calculamos el vector entre la bala y el player
		Vector3 direccion=player.position-transform.position;
		direccion.Normalize ();
		Debug.Log ("direccion:"+direccion);
		Debug.Log ("Magnitud:"+direccion.magnitude);

		transform.Translate (direccion * Time.deltaTime*speed);
	}
}
