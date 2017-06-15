using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// importamos el codigo para tener acceso
// a los elementos de UI
using UnityEngine.UI;

public class Lifebar : MonoBehaviour {
	public GameObject _player;
	private Image _image;

	// Use this for initialization
	void Start () {
		_image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		_image.fillAmount = _player.GetComponent<Health> ().health / _player.GetComponent<Health> ().maxHealth;
	}
}
