using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Variables
    public float speedX = 5;
    public float jumpForce = 8;
    public float gravity = -10;

    public float rayLength = 0.6f;

    public LayerMask _mask;

    public bool canControl = true;
    public bool canAttack = true;

    public float invulnerableTime = 1.5f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Health _healthScript;

    private float previousHealth;

    private float verticalSpeed;
	public bool isGrounded;

    private float h;
    private bool pressedJump;

    private float knockback;
    private bool knockbackToRight;
    private float targetAlpha = 0;


    //Variables para el salto doble
    public int DoubleJumps = 0; //Contador para saber si ya hizo el doble salto o no
    public bool isDoubleJump;   //Booleano para saber si puede hacer doble Jump o no
    #endregion

    // Use this for initialization
    void Start()
    {
        //guardamos la referencia la componente Rigidbody 
        //en nuestra variable
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _healthScript = GetComponent<Health>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        ReceiveInputs();

        ManageKnockBack();

        Hurt();

        ManageFlipping();

        ManageBlinking();

        ManageAnimations();
    }
    //FixedUpdate se ejecuta cada 0.02 segundos
    //aqui incluimos todo el codigo que manipule los rigidbodies
    void FixedUpdate()
    {
        //creamos un Vector3 que comienza en zero
        Vector3 moveVector = new Vector3(0, 0, 0);

        //Definimos el knockback
        //Si hay un knockback la velocidad tendra el siguiente valor de "if" y cuando no hay kcnoback, su velocidad será normal, como en "else"
        if (knockback > 0)
        {
            if (knockbackToRight)
            {
                moveVector.x = knockback;
            }
            else
            {
                moveVector.x = -knockback;
            }
        }
        else
        {
            moveVector.x = h * speedX;
        }

        RaycastHit2D hitInfo;

        Vector3 down = new Vector3(0, -1, 0);

        Vector3 boxSize = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        boxSize = boxSize * 0.99f;

        hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, down, rayLength, _mask.value);
        if (hitInfo.collider == null)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }

        Vector3 up = new Vector3(0, 1, 0);
        bool hitUp = false;
        hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, up, rayLength, _mask.value);
        if (hitInfo.collider != null)
        {
            hitUp = true;
        }
        if (hitUp)
        {
            verticalSpeed = -1;
        }

        Vector3 left = new Vector3(-1, 0, 0);
        bool hitLeft = false;
        hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, left, rayLength, _mask.value);
        if (hitInfo.collider != null)
        {
            hitLeft = true;
        }
        /*****************/
        if (hitLeft)
        {
            if (h < 0)
            {
                moveVector.x = 0;
            }
        }
        /*****************/

        Vector3 right = new Vector3(1, 0, 0);
        hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, right, rayLength, _mask.value);
        bool hitRight = false;
        if (hitInfo.collider != null)
        {
            hitRight = true;
        }
        /*****************/
        if (hitRight)
        {
            if (h > 0)
            {
                moveVector.x = 0;
            }
        }
        /*****************/
        if (isGrounded)
        {
            //si estoy en el piso el verticalSpeed es 
            //un valor negativo pequeño... esto es para 
            //asegurarnos que el player toque el piso
            //y no impida el movernos de lado a lado
            verticalSpeed = -0.1f;
            DoubleJumps = 0;                //Reiniciamos el contador de salto doble al tocar el suelo
            isDoubleJump = false;           //Desactivamos la opción del salto doble ya que solo es posible hacer el salto doble en el aire
            if (pressedJump)
            {
                DoubleJumps++;              //Contamos la cantidad de saltos, en este caso sería 1, dado que es el salto normal (el primer salto)				
                verticalSpeed = jumpForce;  //Cambiamos el valor del VerticalSpeed, le asignamos la fuerza de salto
                pressedJump = false;        //ya que hemos aplicado el salto...reseteamos pressedJump
            }

        }
        else
        {
            if (pressedJump)                //Ahora estamos en el aire, y el contador de saltos es 1, por lo que segun nuestro if "Input.GetKeyDown(KeyCode.Space) && DoubleJumps <= 1" hace que pressedJump pueda ser Verdadero
            {
                DoubleJumps++;              //Ahora contamos el segundo salto, diciendole al script que ya estamos saltando dos veces para que no pueda volver a saltar
                verticalSpeed = jumpForce;  //Cambiamos el valor del VerticalSpeed, le asignamos la fuerza de salto
                isDoubleJump = true;        //Activamos la opción del doble salto para que la animación realice el segundo salto
                pressedJump = false;        //Desactivamos esta variable para que no se ejecute indefinidamente
            }
                verticalSpeed += gravity * Time.deltaTime;  //la gravedad se va aplicando al verticalSpeed
            
        }

        moveVector += new Vector3(0, verticalSpeed, 0);

        //en lugar de pasarle los 3 numeros por separado
        //le pasamo a la funcion Translate el Vector3
        //cuando multiplicas un numero por un Vector3
        //Mulitplicas el X, Y y Z por ese numero.
        _rigidbody.velocity = moveVector;
        //transform.Translate (moveVector*Time.deltaTime);
        //transform.Translate (moveX * Time.deltaTime, 0, 0);
    }

    void OnDrawGizmos()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Vector3 boxSize = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        boxSize = boxSize * 0.99f;
        Gizmos.DrawWireCube(transform.position, boxSize);

        Vector3 down = new Vector3(0, -1, 0);
        Vector3 pos = transform.position + (down * rayLength);
        Gizmos.DrawWireCube(pos, boxSize);
    }

    //Controla los inputs del teclado y mouse
    void ReceiveInputs()
    {
        if (canControl)
        {
            //necesitamos leer los inputs en cada frame
            //por eso es que lo colocamos en Update
            //y guardamos el resultado en variables globales que 
            //se usaran en FixedUpdate
            h = Input.GetAxis("Horizontal");
            //Definimos la condición para ejecutar el salto
            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || DoubleJumps <= 1))
            //En esta condición se pregunta si se ha presionado la tecla "Espacio"
            //La otra condición es una combinación de "Si esta en el suelo o si aun no ha realizado el doble salto"
            { 
                //por lo que si esta en el suelo, colocamos en verdadero la variable de PressedJump para saltar
                //o si está en el aire, pero aun no ha saltado por segunda vez, la variable también se activará                
                pressedJump = true; //Activamos esta variable para el salto
            }
        }
        else
        {
            h = 0; //Si el jugador no puede controlar a su personaje entonces hacemos que "h" sea cero
        }
    }
    //se encarga de voltear el SpriteRenderer cuando caminas hacia la izquierda o derecha
    void ManageFlipping()
    {
        if (h < 0)
        {
            _spriteRenderer.flipX = true;       //Si H es menor a 0, hacemos que el objeto mire a la derecha
        }
        if (h > 0)
        {
            _spriteRenderer.flipX = false;	    //Si H es mayor a 0, hacemos que el objeto mire a la izquierda
        }
    }

    //Esta función hace que el personaje parpadee, haciendo el efecto de recibir daño (aca manejamos el alpha, el cual maneja la transparencia de objeto
    void ManageBlinking()
    {
        //Primero, verificamos si el objeto se encuentra en la capa de invencibilidad (Capa 10 => Layer 10)
        if (gameObject.layer == 10)
        {
            Color newColor = _spriteRenderer.color; //Asignamos una variable newColor de tipo Color, para controlar la transparencia
            //Aquí definiremos el valor de la variable TargetAlpha para decirle a la función Lerp como va a hacer la transición de transparencia
            if (newColor.a <= 0.05)
            {
                //Si la transparencia del objeto es menor a 0.05, o sea, casi invisible, haremos que TargetAlpga le diga a Lerp que el objeto se haga visible
                targetAlpha = 1;
            }
                //Caso contrario
            else if (newColor.a >= 0.95)
            {                
                //Si la transparencia del objeto es mayor a 0.95, o sea, casi visible por completo, haremos que TargetAlpga le diga a Lerp que el objeto se haga invisible
                targetAlpha = 0;
            }
            //Aquí hacemos uso de la función Lerp para la transición de transparencia
            //Mathf.Lerp(Origen, Destino, Tiempo);
            //Mathf.Lerp => Es la función Lerp para el Color (Hay otra función Lerp para otras cosas xD)
            //Origen => En este caso del Lerp, le decimos cual es el origen de transparencia (a veces será 0, otras veces será 1)
            //Destino => En este caso del Lerp, le decimos cual será el destino de transparencia (a veces será 1, otras veces será 0)
            //Explicación: Haremos que la transparencia del objeto vaya de 1 a 0 lentamente y cuando llegue a 0, haremos que vuelva a ir a 1 lentamente
            //Haciendo el efecto de "recibir daño"
            newColor.a = Mathf.Lerp(newColor.a, targetAlpha, Time.deltaTime * 20);
            //Ahora que tenemos la transparencia (newColor.a => Es el que maneja el alpha), le asignamos esta transparencia al objeto
            _spriteRenderer.color = newColor;
            //Esto ocurrirá cada frame por lo que en cada frame se verá como el objeto va bajando y subiendo su transparencia
        }
            //Ahora, cuando el objeto ya no se encuentra en la capa de invulnerabilidad, o sea, cuando se acaba el efecto de recibir daño
        else
        {            
            //Hacemos que el objeto ya no sea transparente, porque a veces el objeto se queda semi transparente o completamente transparente
            Color newColor = _spriteRenderer.color;                         //Primero: creamos la variable
            newColor.a = Mathf.Lerp(newColor.a, 1, Time.deltaTime * 20);    //Esto es para aplicarle suavidad al cambio de invisible a visible
            _spriteRenderer.color = newColor;                               //Le asignamos la transparencia al objeto (En este caso sería 1, lo cual hace al objeto completamente visible)
        }
    }

    //controla los parametros del animator
    void ManageAnimations()
    {
        //le pasamos el valor absoluto de h porque cuando presionas
        //hacia la izquierda h se vuelve negativo
        float absH = Mathf.Abs(h);
        _animator.SetFloat("speed", absH);
        _animator.SetFloat("verticalSpeed", verticalSpeed);
        _animator.SetBool("isGrounded", isGrounded);

        //Entonces, cuando se haya saltado una vez hacendo que DoubleJumps sea 1 y al presionar el saltar de nuevo mientras se está en el aire
        //Se activarán los siguientes comandos
        if (DoubleJumps <= 1 && pressedJump == true)
        {
            //Activamos el triger de animacion para volver a animar el salto
            _animator.SetTrigger("isDoubleJump"); 
        }

        if (Input.GetMouseButtonDown(0) && isGrounded && canAttack)
        {
            _animator.SetTrigger("attack");
            canAttack = false;
        }

        
		if (knockback > 0)
            _animator.SetBool("hurt", true);
        else
            _animator.SetBool("hurt", false);
    }

    //esto se encarga de cuando te hacen daño
    void Hurt()
    {
        //si la vida actual es menor a la vida que teniamos antes
        //significa que hemos recibido daño
        if (_healthScript.health < previousHealth)
        {
            //Layer 10 es la capa Invulnerable
            gameObject.layer = 10;  //Hacemos que el objeto sea invulnerable para que no vuelva a recibir daño por unos segundos
            canControl = false;     //Hacemos que el jugador no tenga control del personaje
            knockback = 3;          //Esta es la velocidad con la cual retrocederas al recibir daño
            //Cambiamos la velocidad de VerticalSpeed por si se recibe daño en el aire, de esta manera, esta velocidad irá disminuyendo por la gravedad, si se le pone negativo, ocasionará que suba el objeto
            verticalSpeed = 0.1f;  

			//Debemos verificar que el LastAttacker exista
			if (_healthScript.lastAttacker) {
				//Aquí averiguamos en donde esta el jugador, si está a la derecha o izquierda del objeto
				if (transform.position.x < _healthScript.lastAttacker.transform.position.x) {
					//Si está a la izquierda hacemos que el knockbackToRight sea falso, haciendo que el objeto se vaya a la izquierda
					knockbackToRight = false;
				} else {
					//Si está a la derecha hacemos que el knockbackToRight sea falso, haciendo que el objeto se vaya a la derecha
					knockbackToRight = true;
				}
			}
            Invoke("MakePlayerVulnerable", invulnerableTime);   //Invocamos al metodo MakePlayerVulnerable
        }
        //despues de hacer el if actualizamos la variable previousHealth
        previousHealth = _healthScript.health;

    }
    //Aquí manejamos el KnockBack
    void ManageKnockBack()
    {
        //Si knockback tiene valor positivo (arriba le pusimos el valor de 3)
        if (knockback > 0)
        {
            //Hacemos que el personaje retroceda con la velocidad del knockback
            knockback -= Time.deltaTime * 2.5f;
            if (knockback <= 0)
            {
                //Cuando knockback sea mejor o igual a 0 hacemos que el objeto sea controlable de nuevo
                canControl = true;
            }
        }
    }
    void MakePlayerVulnerable()
    {
        //Layer 8 es la capa Jugadores
        gameObject.layer = 8;
    }
}