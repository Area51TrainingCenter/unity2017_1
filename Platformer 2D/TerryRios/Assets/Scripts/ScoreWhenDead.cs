using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWhenDead : MonoBehaviour {
	public int score = 100;
	private ScoreManager _scoreManager;
	private Health _healthScript;
	// Use this for initialization
	void Start () {
		//primero buscamos al GameObject del ScoreManager usando 
		//GameObject.Find (el parametro es el nombre del objeto)
		//y luego obtenemso el componente dentro de ese GameObject
		_scoreManager = GameObject.Find ("Score manager").GetComponent<ScoreManager>();
		_healthScript = GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_healthScript.health <= 0) {
			_scoreManager.score += score;
		}
	}
}
