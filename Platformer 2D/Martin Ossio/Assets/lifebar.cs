using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class lifebar : MonoBehaviour {

	public Health playerHealth;
	private Image displayHealth;


	// Use this for initialization
	void Start () {
		displayHealth = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		displayHealth.fillAmount = playerHealth.health / playerHealth.maxHealth;
			
	}
}
