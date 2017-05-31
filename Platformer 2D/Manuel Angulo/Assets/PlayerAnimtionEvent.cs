using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimtionEvent : MonoBehaviour {
	public GameObject playerObject;
	public GameObject boxL;
	public GameObject boxR;
	// Use this for initialization
	void Start () {
		
	}
	

	public void canControlOn () {
		playerObject.GetComponent <PlayerMovement> ().cancontrol = true;
	}

	public void canControlOff () {
		playerObject.GetComponent <PlayerMovement> ().cancontrol = false;
	}

	public void canAtackOn () {
		if (GetComponent<SpriteRenderer> ().flipX) {
			boxL.GetComponent <BoxCollider2D> ().enabled = true;
		}	else{
		boxR.GetComponent <BoxCollider2D> ().enabled = true;
			}
	}
	public void canAtackOff () {
		boxL.GetComponent <BoxCollider2D> ().enabled = false;
		boxR.GetComponent <BoxCollider2D> ().enabled = false;
	}
}