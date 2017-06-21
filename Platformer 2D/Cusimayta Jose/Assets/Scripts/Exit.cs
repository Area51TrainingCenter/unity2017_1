using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	PlayerMovement _playerMovement;
	Animator _playerAnimator;
	Rigidbody2D _playerRigidBody2D;
	Transform _playerTransform;
	public bool _elevar;
	public bool _animar;
	public Camera _camera;
	// Use this for initialization
	void Start () {	
		_camera.GetComponent<PlayerCamara> ().enabled = false;
	}

	
	// Update is called once per frame
	void Update () {
		if (_elevar) {
			Invoke ("Elevar", 1);
		}
		if(_animar){
			if (_playerMovement.isGrounded) {
				IniciarAnimacion();
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{		
		_playerTransform = other.GetComponent<Transform> ();
		_playerRigidBody2D = other.GetComponent<Rigidbody2D> ();
		_playerMovement=other.GetComponent<PlayerMovement>();	
		_playerAnimator = other.GetComponentInChildren<Animator> ();
		_playerMovement.canControl = false;
		_animar = true;
	}
	void IniciarAnimacion(){
		_playerRigidBody2D.velocity=new Vector2(0,0);
		_playerMovement.enabled = false;
		_playerAnimator.SetTrigger ("exit");
		_elevar = true;
		_animar = false;
	}
	void Elevar(){
		Vector3 moveVector = new Vector3(0, 5, 0);
		_playerTransform.Translate(moveVector*Time.deltaTime);
		Invoke ("ChangeScene", 1.5f);
	}
	public void ChangeScene(){
		SceneManager.LoadScene ("WinScene");
	}
}