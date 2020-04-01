using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb;

    [Space]
    [Header("Variables Numericas")]
    [SerializeField]
    private float speed = 0;
    private float moveInput;

    //Pare ver si está tocando el suelo
    private bool isGrounded;
    [SerializeField]
    private float jumpForce = 0;
    [SerializeField]
    private float jumpTime = 0;


    //Numero de saltos que puede realizar el jugador
    private int numJump = 1;
    [Space]
    [Header("Otras")]
    //Objeto invisible para detectar la colision con el suelo
    //Se localizara en la parte mas baja del jugador
    public Transform layerPosition;
    //Tamaño del objeto invisible que detecta la colision con el suelo
    private const float LAYER_SIZE = 0.1f;
    //Mascara para detectar que es suelo y que no
    public LayerMask whatIsGround;

    //Variable usada para contar el tiempo que el jugador
    //está saltando, nunca será mayor que jumpTime
    private float jumpTimeCounter = 0;

    private bool isJumping;

    Vector2 characterScale;
    #endregion

    void Start()
    {
        //Cacheo del Rigidbody 
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HorizontalMove();
        Flip();

        //Devuelve true cuando está en el suelo
        isGrounded = Physics2D.OverlapCircle(layerPosition.position, LAYER_SIZE, whatIsGround);

        Jump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    //Aquí están todos los métodos creados para este Script
    #region Metodos

    /// <summary>
    /// Gestiona el movimiento horizontal del usuario.
    /// </summary>
    void HorizontalMove()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    /// <summary>
    /// Gestiona el salto del usuario, que es mayor mientras más tiempo deje pulsada la tecla
    /// de salto. El tiempo de salto es configurable desde el inspector
    /// </summary>
    void Jump()
    {
        if (isGrounded || rb.velocity.y == 0)
        {
            numJump = 1;
        }

        //Si está en el suelo y pulsa espacio, salta
        if (numJump > 0 && Input.GetButtonDown("Vertical"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            numJump--;
            rb.velocity = Vector2.up * jumpForce;
        }


        /*
         * Si mantiene pulsado espacio, está saltando y el contador es mayor a 0, sigue 
         * propulsandose hacia arriba hasta que el contador llegue a 0 o el jugador deje
         * de pulsar el boton de salto
         */
        if (Input.GetButton("Vertical"))
        {

            if (jumpTimeCounter > 0 && isJumping)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
                isJumping = false;
        }

        if (Input.GetButtonUp("Vertical"))
            isJumping = false;

        //Debug.Log(isGrounded);
    }

    /// <summary>
    /// Voleta horizontalmente al jugador cambiando su escala
    /// en el eje X según la dirección del movimiento horitonztal
    /// </summary>
    void Flip()
    {
        if(!GameManager.instance.GetMenu())
        {
            characterScale = transform.localScale;

            if (moveInput < 0)
            {
                characterScale.x = -1;
                //GameManager.instance.UpdatePlayerLooking(false); // se está ahora mirando a la izda. --- Javier
            }

            if (moveInput > 0)
            {
                characterScale.x = 1;
                //GameManager.instance.UpdatePlayerLooking(true); // se está ahora mirando a la dcha. ---- Javier
            }

            transform.localScale = characterScale;
        }
    }

    #endregion
}