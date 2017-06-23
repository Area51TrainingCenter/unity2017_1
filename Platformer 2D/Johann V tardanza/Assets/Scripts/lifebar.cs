using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importamos el codigo de los elmentos de
//UI (por defecto no nesta disponible)
using UnityEngine.UI;

public class lifebar : MonoBehaviour {
	public Health playerHealth;
	private Image _image;
	// Use this for initialization
	void Start () {
		_image = GetComponent <Image> (); 

	}
	
	// Update is called once per frame
	void Update () {

		_image.fillAmount = playerHealth.health / playerHealth.maxHealth;
	}
}
