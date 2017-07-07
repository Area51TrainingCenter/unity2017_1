using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {
	public GameObject _prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool disparo = Input.GetMouseButtonDown(0);
		if (disparo)
		{
			//Instantiate crea un clon del prefab que le damos
			Instantiate(_prefab,transform.position,transform.rotation);
		}
	}
}
