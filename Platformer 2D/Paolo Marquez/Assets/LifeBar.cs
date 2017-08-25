using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importamos el codigo de los elemementos de UI (por defecto no esta disponible)

using UnityEngine.UI;

public class LifeBar : MonoBehaviour {
	private Health player_salud;
	private float nivelActualBarra;
	private Image lifeBar;

	// Use this for initialization
	void Start () {
		player_salud = GameObject.FindGameObjectWithTag ("Player").GetComponent<Health> ();
		Debug.Log ("Nivel de barra actual=" + nivelActualBarra);
		lifeBar=GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		//player_salud = GameObject.FindGameObjectWithTag ("Player").GetComponent<Health> ();
		modificarBarra (player_salud.maxHealht,player_salud.healht);
		//Debug.Log ("Nivel de barra actual=" + nivelActualBarra);
	}

	void modificarBarra(float saludMaxima,float salu){
		nivelActualBarra=salu/saludMaxima;
		//Debug.Log ("Nivel de barra actual=" + nivelActualBarra);
		lifeBar.fillAmount = nivelActualBarra;
	}
}
