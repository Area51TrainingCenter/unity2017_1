using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// importamos el codigo de los elementos de UI
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// barra de vida
public class LifeBar : MonoBehaviour {
	// hipercan
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

		if(vidaactual == 0){
			SceneManager.LoadScene ("gameOver");
		}

	}


}
