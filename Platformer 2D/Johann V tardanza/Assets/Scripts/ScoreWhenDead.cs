using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWhenDead : MonoBehaviour {
	public int score = 100;
	private ScoreManager _scoreManager; 
	private Health _healtScript;
	// Use this for initialization
	void Start () {
		//priemro buscamos al GameObject del ScoreManager usando
		//GameObject.Find (el parmetro es el nombre del objeto)
		//y luego obtenemos el componente dentro de ese GameObject
		_scoreManager = GameObject.Find ("Score manager").GetComponent<ScoreManager>() ;
		_healtScript = GetComponent<Health> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (_healtScript.health <= 0) {
			_scoreManager.Score += score;
		}
	}
}
