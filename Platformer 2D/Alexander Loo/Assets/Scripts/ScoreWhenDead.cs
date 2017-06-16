using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWhenDead : MonoBehaviour {

	private ScoreManager _scoreManager;
	private Health _heatlh;
	public int score = 100;

	void Start(){
		//busca el nombre del objeto -->GameObject.Find("nombre del objeto")
		_scoreManager = GameObject.Find ("Score Manager").GetComponent<ScoreManager>();
		_heatlh = GetComponent<Health> ();
	}
	void Update(){

		if (_heatlh.health <= 0) {
			_scoreManager.score += score;
		}
	}
}
