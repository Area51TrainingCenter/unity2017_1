using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	
	public Renderer _cube;

	public int count;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			for (int j = 0; j < count; j++) {
				Renderer newCube = Instantiate (_cube, transform.position, transform.rotation) as Renderer;
				newCube.material.color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
					
			}
			//StartCoroutine (CreateCube ());
		}
	}
	//las corutinas siempre retornan un IEnumerator
	IEnumerator CreateCube(){
		
		for (int i = 0; i < count/5; i++) {
			for (int j = 0; j < 5; j++) {
				Instantiate (_cube, transform.position, transform.rotation);
			}
			//espera un frame
			yield return null;
		}

	}
}
