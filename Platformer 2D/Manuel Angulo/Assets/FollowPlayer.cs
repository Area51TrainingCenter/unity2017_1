using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform player;
	public string targetTag;
	public float speed = 1;
	// Use this for initialization
	void Start () 
	{
		//buscamos en la escena el GameObject que tenga el tag player
		//despues obtenemos el componente Transform de ese GameObject
		//en vez de GetComponent<Transform>() podemos poner solo transform (es como una abreviatura)
		//este nos sirve para hallar el transform del GameObject
		player = GameObject.FindGameObjectWithTag (targetTag).GetComponent<Transform>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//calculamos el vector entre la bal y el player
		Vector3 direccion = player.position - transform.position;
		//normalizamos el vector para q  su longitud sea 1
		direccion.Normalize ();
		//movemos el objeto usando el vector
		transform.Translate (direccion * Time.deltaTime * speed);
	}
}
