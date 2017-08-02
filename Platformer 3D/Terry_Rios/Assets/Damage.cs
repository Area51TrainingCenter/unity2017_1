using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	
	public Transform owner;
	public float _damage = 20;
	public GameObject _particulas;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Enemy")) {

			other.GetComponent<health> ().ChangeHealth (_damage);
			Instantiate (_particulas, transform.position, transform.rotation);
			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize();
			other.GetComponent<enemigo_ai> ().AddImpact (dir, 30);
		}



	}
}
