using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour {

	private bool goUp = false;
	private GameObject player;
	private ScoreManager _scoremanager;
	private bool touchedtrigger = false;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		_scoremanager = GameObject.Find ("Score manager").GetComponent<ScoreManager>();


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) 
		{

			player.GetComponent<PlayerMovement> ().canControl = false;
			touchedtrigger = true;

		}
	}
	

	// Update is called once per frame
	void Update () 
	{

		if (player.GetComponent<PlayerMovement>().isGrounded&&touchedtrigger) 
		{

			player.GetComponent<PlayerMovement> ().enabled = false;
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponentInChildren<Animator> ().SetTrigger ("exit");
			Invoke ("StartGoingUp", 1.0f);
			Invoke ("ChangeScene", 2.8f);
			touchedtrigger = false;
			
		}

		if (goUp) 
		{
			player.transform.Translate (0, 10*Time.deltaTime, 0);
		}

	}

	void StartGoingUp()
	{
		goUp = true;
	}
	void ChangeScene()
	{
		PlayerPrefs.SetInt("playerscore",_scoremanager.score);
		SceneManager.LoadScene ("winScreen");
	}
}
