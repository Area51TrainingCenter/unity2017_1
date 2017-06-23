using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWhenDeath : MonoBehaviour {
	public int score=100;
	private ScoreManager _scoreManager;
	// Use this for initialization
	void Start () {
		_scoreManager=GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Health>().healht<=0) {
			_scoreManager.score += score;
			this.enabled = false;
		}
	}
}
