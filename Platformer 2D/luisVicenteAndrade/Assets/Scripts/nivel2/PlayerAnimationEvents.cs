using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{

    public GameObject playerObject;
    public GameObject rightHitbox;
    public GameObject leftHitbox;
    private SpriteRenderer _spriteRenderer;

    // Use this for initialization
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();                   //inicializamos la variable del spriteRenderer
    }

    public void EnablePlayerControl()
    {
        playerObject.GetComponent<PlayerMovement>().canControl = true;      //Habilitamos el control del jugador
    }

    public void DisablePlayerControl()
    {
        playerObject.GetComponent<PlayerMovement>().canControl = false;     //Deshabilitamos el control del jugador
    }

    public void EnableHitboxes()
    {
        //Ponemos la condicion para saber que caja de daño del jugador activaremos
        //La condicion es si el personaje ha sido girado en el eje X o no (flipX)
        if (_spriteRenderer.flipX)
        {
            leftHitbox.GetComponent<Collider2D>().enabled = true;           //Habilitamos las cajas de daño del jugador de la derecha
        }
        else
        {
            rightHitbox.GetComponent<Collider2D>().enabled = true;          //Habilitamos las cajas de daño del jugador de la izquierda
        }
    }

    public void DisableHitboxes()
    {
        //Deshabilitamos las cajas de daño del jugador
        rightHitbox.GetComponent<Collider2D>().enabled = false;
        leftHitbox.GetComponent<Collider2D>().enabled = false;

    }

	public void EnableCanAttack(){
		playerObject.GetComponent<PlayerMovement> ().canAttack = true;	    //Habilitamos el ataque del jugador
	}

	public void DisableCanAttack(){
        playerObject.GetComponent<PlayerMovement>().canAttack = false;     //Deshabilitamos el ataque del jugador
	}

	public void setAttackHitboxsize_1() {
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0, 0);
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1, 1);

		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0, 0);
		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (1, 1);
	}	

	public void setAttackHitboxsize_2() {
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.5672339f, 0);
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (2.134468f, 1);

		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.5672339f, 0);
		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (2.134468f, 1);
	}

	public void setAttackHitboxsize_3() {
		rightHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (0.08456753f, 0);
		rightHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (2.134468f, 1);

		leftHitbox.GetComponent<BoxCollider2D> ().offset = new Vector2 (-0.08456753f, 0);
		leftHitbox.GetComponent<BoxCollider2D> ().size = new Vector2 (2.134468f, 1);
	}
	public void Pausa (){
		GetComponent <Animator> ().speed = 0;
		Invoke ("Reanudar", 1);
	}
	public void Reanudar(){
		GetComponent <Animator> ().speed = 1;

	}
}


