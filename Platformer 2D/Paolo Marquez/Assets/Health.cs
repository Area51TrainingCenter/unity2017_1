using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float healht=100;
	public float maxHealht=100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeHealth(float damage){
		healht -= damage;
		if (healht>maxHealht) {
			healht = maxHealht;
		}
		if (healht<0) {
			healht = 0;
		}
	}
}
