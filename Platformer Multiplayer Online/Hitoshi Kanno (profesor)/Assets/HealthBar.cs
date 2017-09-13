using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {
	public Health _healthScript;
	private Image _image;
	// Use this for initialization
	void Start () {
		_image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		_image.fillAmount = _healthScript._health / _healthScript._maxHealth;
	}
}
