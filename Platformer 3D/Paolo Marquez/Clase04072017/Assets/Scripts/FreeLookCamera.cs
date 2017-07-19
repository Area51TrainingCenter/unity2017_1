using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distancia=5f;
	public float angulo = 90f;
	public float sensibilidadMouse = 10f;

	// Use this for initialization
	void Start () {
		//distancia = transform.position - target.position;
		//offset = new Vector3(0,3,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			float mouseX = Input.GetAxis ("Mouse X");
			angulo += mouseX*sensibilidadMouse;

			Quaternion newRotation = Quaternion.Euler (0,angulo,0);
			//el vector se rota de acuerdo a la nueva rotacion y se guarda en la variable behind
			Vector3 behind = newRotation*Vector3.forward;
			transform.position = target.position +offset+behind*distancia;
			transform.LookAt (target.position+offset);
		}

	}


}
