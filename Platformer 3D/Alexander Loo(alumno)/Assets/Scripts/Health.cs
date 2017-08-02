using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 100;

	public void ChangeHealth(float damage){

		health -= damage;
	}
}
