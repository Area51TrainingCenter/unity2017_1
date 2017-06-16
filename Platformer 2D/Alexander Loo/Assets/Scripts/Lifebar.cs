using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using es para importar librerías
using UnityEngine.UI;

public class Lifebar : MonoBehaviour {
	
	public Health playerHealth;
	private Image _image;

	void Start(){
		_image = GetComponent<Image> ();
	}

	void Update(){
		//sacamos el porcentaje de la vida de zero...vida actual / vida maxima
		_image.fillAmount = playerHealth.health / playerHealth.maxHealth;
	}
}
