using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

	public Health _healthscript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Image> ().fillAmount = _healthscript._health / _healthscript._Maxhealth;
		
	}
}
