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

	// Box RIGHT - Ataque 1
	public void SetAttack1HitboxSize(){			

		_boxright.GetComponent<BoxCollider2D> ().size = new Vector2 (0.9757428f, 1f);
		_boxright.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.01212859f, 0f);	

		_boxLeft.GetComponent<BoxCollider2D> ().size = new Vector2 (0.9747028f, 1f);
		_boxLeft.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.01212859f, 0f);

	}

	public void SetAttack2HitboxSize(){
		
		_boxright.GetComponent<BoxCollider2D> ().size = new Vector2 (1.421691f, 0.4888293f);
		_boxright.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.2108457f, 0.08244696f);	


		_boxLeft.GetComponent<BoxCollider2D> ().size = new Vector2 (1.466301f, 0.4558502f);
		_boxLeft.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.2584446f, 0.05771273f);	

	}

	public void SetAttack3HitboxSize(){
	}


}
