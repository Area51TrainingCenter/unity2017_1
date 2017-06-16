using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemigo, cuando se muera el enemigo la variable score aumente la cantiad
public class ScoreWhenDead : MonoBehaviour {

	public int score = 100;// da el puntaje cuando muera
	private ScoreManager _scoreManager;

	// Use this for initialization
	void Start () {
		// primero buscamos al GamObject del ScoreManager usando 
		// GameObject.Find( el parametro es el nombre del objeto)
		_scoreManager = GameObject.Find ("Score manager").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GetComponent<Health> ().health == 0){
			_scoreManager.score += score;
		}


	}
}
