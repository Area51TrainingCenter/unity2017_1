using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private Health _health;
	void Start () {
		_health = GetComponent<Health> ();
	}
	

	void Update () {

		if (_health.health == 0) {
			Destroy (gameObject);
		}

	}
}
