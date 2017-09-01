using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour {

	public Image greenHealthImage, redHealthImage;
	public Health playerHealth;

	void Start(){

		greenHealthImage.color = Color.green;
	}

	void Update(){

		if (playerHealth.health < playerHealth.maxHealth / 2) {
			redHealthImage.enabled = true;
			greenHealthImage.color = Color.yellow;
		}
		greenHealthImage.fillAmount = playerHealth.health / playerHealth.maxHealth;

	}
}
