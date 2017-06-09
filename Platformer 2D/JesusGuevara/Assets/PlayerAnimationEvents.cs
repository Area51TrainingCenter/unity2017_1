using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {

	public GameObject _gameobject;
	public GameObject _boxLeft;
	public GameObject _boxright;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void apagarControl(){
		_gameobject.GetComponent<Movimiento> ().controlPlayer = false;	

	}

	public void activarControl(){
		_gameobject.GetComponent<Movimiento> ().controlPlayer = true;	
	}

	public void EnableHitboxes(){
		if (_gameobject.GetComponent<Movimiento> ()._spriteRenderer.flipX)
		{
			_boxLeft.GetComponent<Collider2D>().enabled = true;
		}
		else
		{
			_boxright.GetComponent<Collider2D>().enabled = true;
		}
	}

	public void DisableHitboxes(){
		_boxright.GetComponent<Collider2D> ().enabled = false;
		_boxLeft.GetComponent<Collider2D> ().enabled = false;

	}

	public void activarCanAttack(){
		_gameobject.GetComponent<Movimiento> ().canAttack = true;	
	}
	public void desactivarCanAttack(){
		_gameobject.GetComponent<Movimiento> ().canAttack = false;	
	}


}
