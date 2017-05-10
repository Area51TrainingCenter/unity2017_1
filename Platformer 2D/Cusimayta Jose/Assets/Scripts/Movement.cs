using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speedX = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MovimientoLateral ();
	}

	void MovimientoLateral(){
		Vector3 moveVector = new Vector3 (0, 0, 0);
		float h = Input.GetAxis ("Horizontal");
		moveVector.x = h * speedX;
		transform.Translate (moveVector * Time.deltaTime);



		#region Movimiento con vectores
		/*
		Vector3 moveVector = new Vector3 (0, 0, 0);
		bool PressA = Input.GetKey (KeyCode.A);
		bool PressD = Input.GetKey (KeyCode.D);
		if (PressD)
		{
			moveVector.x = speedX;
		}
		if (PressA)
		{
			moveVector.x = -speedX;
		}
		transform.Translate (moveVector * Time.deltaTime);
		*/
		#endregion
	}		
}