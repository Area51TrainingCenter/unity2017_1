using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danio : MonoBehaviour {
	public float damage = 20;

	public GameObject explosion;
	public Transform owner;
	// Use this for initialization
	void Start () {		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if(other.CompareTag("enemigo")){
			other.GetComponent<Health>().ChangeHealth(damage); 
			Instantiate(explosion, transform.position, Quaternion.identity);
			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize ();
			other.GetComponent<EnemyAI> ().AddImpact (dir, 10f);
		}
	}
}
