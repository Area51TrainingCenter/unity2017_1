using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour {
	public GameObject Padre;
	public GameObject Right;
	public GameObject left;

	public SpriteRenderer _SpriteRenderer;
	// Use this for initialization
	void Start () {
		_SpriteRenderer = GetComponent <SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnablePlayerControl (){
		Padre.GetComponent <Movimiento>().canCondicion = true;

	}
	public void DisablePlayerControl (){
		Padre.GetComponent <Movimiento>().canCondicion = false;
	}
	public void EnablePlayerAtacaks (){
		if (_SpriteRenderer.flipX == true) {
			left.GetComponent <Collider2D> ().enabled = true;

		} else {
			Right.GetComponent <Collider2D> ().enabled = true;
		}			
	}
	public void DisablePlayerAtacaks (){
			Right.GetComponent <Collider2D> ().enabled = false;
			left.GetComponent <Collider2D> ().enabled = false;
			
	}
	public void EnablePlayerAtaca (){
		Padre.GetComponent <Movimiento>().canAtaca = true;

	}
	public void DisablePlayerAtaca (){
		Padre.GetComponent <Movimiento>().canAtaca = false;
	}

}

