using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {
	public GameObject Player;	//Declaramos al objeto Player, para poder manipular sus componentes
	Health _healthPlayer;		//También declaramos una variable Health, para obtener los datos de la vida del Jugador
	Image lifePoints;			//Esta variable sirve para modificar los datos de la imagen (en este caso, modificaremos el fill amount)

	// Use this for initialization
	void Start () {
		lifePoints= GetComponent<Image>();					//Declaramos la variable LifePoints, la cual manejará la imagen de los puntos de vida
		_healthPlayer = Player.GetComponent<Health> ();		//Declaramos la vida del jugador, la cual será el script dentro del Player
	}
	
	// Update is called once per frame
	void Update () {		
		lifePoints.fillAmount = _healthPlayer.health / _healthPlayer.maxHealth;	//Aplicamos una operación para obtener un porcentaje de cuanta vida tiene
	}
}