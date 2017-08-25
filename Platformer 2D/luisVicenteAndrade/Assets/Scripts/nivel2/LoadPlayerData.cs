using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerData : MonoBehaviour {
	public GameObject _player;
	// Use this for initialization
	void Start () {
		float vida = PlayerPrefs.GetFloat ("PlayerMaxVida", 100);
		_player = GameObject.FindGameObjectWithTag ("Player");
		Health _health = _player.GetComponent<Health> ();
		_health.maxHealth = vida;
		_health.health = _health.maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
