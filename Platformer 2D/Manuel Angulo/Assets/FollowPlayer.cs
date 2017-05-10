using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () 
	{
		//buscamos en la escena el GameObject que tenga el tag player
		//despues obtenemos el componente Transform de ese GameObject
		//en vez de GetComponent<Transform>() podemos poner solo transform (es como una abreviatura)
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//calculamos el vector entre la bal y el player
		Vector3 direccion = player.position - transform.position;
		//normalizamos el vector para q  su longitud sea 1
		direccion.Normalize ();
		//movemos el objeto usando el vector
		transform.Translate (direccion * Time.deltaTime);
	}
}
