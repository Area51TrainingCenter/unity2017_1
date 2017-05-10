using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecusion : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direccion = player.position - transform.position;
		direccion.Normalize ();
		transform.Translate (direccion * 5 * Time.deltaTime);
	}
}
