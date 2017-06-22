using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importamos el codigo de los elementos de
//UI (por defecto no esta disponible)
using UnityEngine.UI;

public class Lifebar : MonoBehaviour {
	public Health _healthScript;
	private Image _image;
	// Use this for initialization
	void Start () {
		_image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		_image.fillAmount = _healthScript.health / _healthScript.maxHealth;
	}
}
