using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public PlayerController player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float vidaActual = player.GetComponent<Health> ().health / player.GetComponent<Health> ().healthMax;
		GetComponent<Image> ().fillAmount = vidaActual;
	}
}
