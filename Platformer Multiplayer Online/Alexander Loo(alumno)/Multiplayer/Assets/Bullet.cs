using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float damage = 20;

	void OnTriggerEnter2D(Collider2D other){
		
		other.GetComponent<Health>().TakeDamage(damage:damage);
		Destroy (gameObject);
	}
}
