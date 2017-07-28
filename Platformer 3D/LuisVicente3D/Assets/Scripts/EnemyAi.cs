using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {
	public Vida _vida;
	// Use this for initialization
	void Start () {
		_vida = GetComponent<Vida> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_vida.vida <= 0) {
			Destroy (gameObject);
		}
	}
}
