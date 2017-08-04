using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	public void ChangeHealth(float damage){
		health -= damage;
	}
}
