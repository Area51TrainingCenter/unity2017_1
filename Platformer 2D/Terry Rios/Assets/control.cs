using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

    public float speedX = 5;
	private float gravity = -10;
	private Rigidbody _rigidbody; 
	private float verticalspeed;
	public float raylength = 0.6f;

	// Use this for initialization
	void Start () 
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 movevector = new Vector3(0,0,0);

		float h = Input.GetAxis ("Horizontal");

		movevector.x = h * speedX;

		Vector3 down = new Vector3 (0, -1, 0);

		//Physics.Raycast genera un rayo invisible que te devuelve true si el rayo toca algo y false si es que no 

		bool isgrounded = Physics.Raycast (transform.position, down, raylength);

		if (isgrounded == true) 
		{
			//si estoy e3n el piso el verical speed es un valor negativo pequeño para asegurarnos de
			//que toque el suelo y podamos movernos
			verticalspeed = -0.1f;

		} 
		else 
		{
			verticalspeed += gravity*Time.deltaTime;
		
		
		}




		//la gravedad se va aplicando al verticalspeed



		movevector += new Vector3 (0, verticalspeed, 0);

		/*
		//A

		bool KeyaPressed = Input.GetKey(KeyCode.A);

		if (KeyaPressed)
		{
			movevector.x = -speedX;
		}

		//D

		bool KeydPressed = Input.GetKey(KeyCode.D);

		if (KeydPressed)
		{
			movevector.x = speedX;
		}

		*/
		//transform.Translate(movevector*Time.deltaTime);
		_rigidbody.velocity = movevector;

		}


}