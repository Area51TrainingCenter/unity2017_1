using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform Player;

	// Use this for initialization
	void Start () {
		// buscamos en la escena el GameObject que tenga el tag Player
		// despues obtenemos el componente TRansform de ese GameObject
		   Player = GameObject.FindGameObjectWithTag ("Player").transform;
		// Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>; // Otra forma de llamar al transform
	}
	
	// Update is called once per frame
	void Update () {
		// obtenemos la direccion ( se calcular la longitud, el resultado sea positivo o negativo, se considera solo el numero, osea positivo )
		Vector3 direccion = Player.position - transform.position;
							// PLAYER 		  // PELOTA

		// normalizamos el vector para que su longitud sea 1
		direccion.Normalize();

		// Debug.Log (direccion);
		// Debug.Log (direccion.magnitude);

		transform.Translate (direccion*Time.deltaTime);

	}
}
