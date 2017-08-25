using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualizaVida : MonoBehaviour {
	public string name="cora1";
	public float salud;
	// Use this for initialization
	void Start () {
		
			if (PlayerPrefs.GetInt(name,0)==1) {
			   Debug.Log ("estado corazon: "+PlayerPrefs.GetInt(name,0));
				Destroy (gameObject);
			}


		else PlayerPrefs.SetInt ("cora1", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.U)) {
			PlayerPrefs.DeleteAll ();
		}
	}



	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			
			Debug.Log ("Me cruce con player y le agregue mas vida extra");
			other.GetComponent<Health> ().maxHealht+=salud;
			other.GetComponent<Health> ().healht += salud;
			PlayerPrefs.SetFloat ("playerMaxHealth",other.GetComponent<Health> ().maxHealht);
			PlayerPrefs.SetInt (name, 1);
			Destroy (gameObject);;
		}
	}
}
