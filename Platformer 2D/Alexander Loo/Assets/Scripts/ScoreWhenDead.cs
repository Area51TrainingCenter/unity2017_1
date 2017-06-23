using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWhenDead : MonoBehaviour {

	private ScoreManager _scoreManager;
	private Health _health;
	public int score = 100;

	void Start(){
		//busca el nombre del objeto -->GameObject.Find("nombre del objeto")
		_scoreManager = GameObject.Find ("Score Manager").GetComponent<ScoreManager>();
		_health = GetComponent<Health> ();
	}
	void Update(){

		if (_health.health <= 0) {
			_scoreManager.score += score;
			//this hace referencia a al mismo script donde se escribe(ScoreManager en este caso)
			this.enabled = false;
		}
	}
}
