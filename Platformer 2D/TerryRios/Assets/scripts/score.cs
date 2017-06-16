using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {

	public int _score = 100;
	private score_manager _scoremanager;

	// Use this for initialization
	void Start () 
	{

		_scoremanager = GameObject.Find("score manager").GetComponent<score_manager>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (GetComponent<health> ().Health == 0) 
		{

			_scoremanager.score += _score;		
		} 	
		
	}
}
