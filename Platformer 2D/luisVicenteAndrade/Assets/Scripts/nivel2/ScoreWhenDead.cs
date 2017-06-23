using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWhenDead : MonoBehaviour {
	public int score = 100;
	private ScoreManager _scoreManager;
	public Health _health;

	// Use this for initialization
	void Start () {
		_scoreManager = GameObject.Find ("Score Manager").GetComponent<ScoreManager> ();
		_health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_health.health <= 0) {
			_scoreManager.score += score;
			this.enabled = false;
		}

	}
}
