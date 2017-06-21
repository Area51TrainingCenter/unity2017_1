using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// importamos el codigo de los elementos de UI
using UnityEngine.UI;
// barra de vida
public class LifeBar : MonoBehaviour {

	public GameObject _gameobject;
	private Image image;

	// Use this for initialization
	void Start () {
//		vidaactual / vidamaximo;
		image = GetComponent<Image>();
		

	}
	
	// Update is called once per frame
	void Update () {

	
		float vidaactual =  _gameobject.GetComponent<Health> ().health;
		float vidamaxima =  _gameobject.GetComponent<Health> ().maxHealth;
		image.fillAmount = vidaactual/vidamaxima ;


	}


}
