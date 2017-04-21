using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour {
	public GameObject _prefab;

	// Use this for initialization
	void Start () {
		////Instantiate Crea un clon del prefab que le damos
		//Instantiate(_prefab);
	}
	
	// Update is called once per frame
	void Update () {
		//disparar
        // bool keyDPressed = Input.GetKeyDown(KeyCode.Space);
		if (Input.GetMouseButtonDown(0))
        {
				//Instantiate Crea un clon del prefab que le damos
		Instantiate(_prefab, transform.position, transform.rotation);
        }

	}
}
