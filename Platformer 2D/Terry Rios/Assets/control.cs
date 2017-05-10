using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

    public float speedX = 5;
	public float speedY = 5;	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 movevector = new Vector3(0,0,0);

		float h = Input.GetAxis ("Horizontal");

		movevector.x = h * speedX;



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
		transform.Translate(movevector*Time.deltaTime);


		
	}


}