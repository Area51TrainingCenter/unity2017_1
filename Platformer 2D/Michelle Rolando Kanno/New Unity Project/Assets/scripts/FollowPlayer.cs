using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
		//en la escena buscamos el GameObject que tenga el tag Player
		//después obtenemos el componente transform de ese GameObject
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//calculamos el vector entre la bala y el player
		Vector3 direccion = player.position - transform.position;
		//normalizamos el vector para que su longitud sea 1
		direccion.Normalize ();
		//Debug.Log (direccion);
		//Debug.Log (direccion.magnitude);

		transform.Translate (direccion * Time.deltaTime);
	}
}
