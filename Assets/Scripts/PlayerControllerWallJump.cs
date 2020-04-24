﻿using UnityEngine;

public class PlayerControllerWallJump : MonoBehaviour
{
    #region Variables

    //Input System
    PlayerInputActions inputActions;

    //-1 si mira a la izquierda y 1 si mira a la derecha
    private float movementInputDirection;

    Vector2 characterScale;

    public bool isWalking;      //is walking de momento no sirve pa na
    public bool isGrounded;         //Comprueba si toca el suelo
    public bool isTouchingWall;     //Comprueba si toca un muro
    public bool isWallSliding;      //Comprueba si se está deslizando
    public bool canJump;            //Comprueba si puede saltar

    //Numero de saltos disponibles
    int numJumpLeft = 1;
    //Variables de control para el salto
    bool gettingOffFloor = false;
    float timeToGetOffFloor = 0.5f;

    //Rigidbody para comprobar la velocidad del player
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    //private int facingDirection = 1;

    public float movementSpeed = 10;
    public float jumpForce = 16;

    //Variables para saltos/deslizamientos/etc
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;
    public float movementForceInAir;
    public float airDragMultiplier = 0.95f;
    public float variableJumpHeighMultiplier = 0.5f;
    public float wallJumpForce;

    //Dirección de los saltos
    public Vector2 wallJumpDirection;
    [SerializeField]
    private float wallJumpTimeOffImpulse;

    private bool playerIsJumpingOffWall = false;

    //Transforms
    public Transform groundCheck;
    public Transform wallCheck;

    //Para saber si está tocando el suelo
    public LayerMask whatIsGround;

    //Para saber las coordenadas del último checkpoint
    private Vector2 spawnpoint;

    #endregion

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Horizontal.performed += ctx => movementInputDirection = ctx.ReadValue<float>();
        inputActions.PlayerControls.Vertical.started += ctx => Jump();
        inputActions.PlayerControls.Vertical.canceled += ctx => FinalizeJump();
    }
    void Start()
    {
        //Cacheamos
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        //Establecemos el número de saltos en 1
        numJumpLeft = 1;

        //facingDirection *= -1;
        characterScale = transform.localScale;

        //Normalizamos los vectores
        wallJumpDirection.Normalize();

    }
    void Update()
    {
        CheckMovementDirection();
        CheckIfCanJump();
        CheckIfWallSliding();
    }
    private void FixedUpdate()
    {
        ApplyMovement();
        CheckGround();
        if (sprite.sprite.name == "Homeopatica")
        {
            CheckWall();
        }
        else
        {
            CloseWallJump();
        }
    }

    /// <summary>
    /// Comprueba si se está deslizando para habilitar un salto más
    /// </summary>
    private void CheckIfWallSliding()
    {
        if (isTouchingWall && !isGrounded)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    /// <summary>
    /// Aplicamos físicas para comprobar si toca el suelo y si toca alguna pared
    /// </summary>
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    private void CheckWall()
    {
        isTouchingWall = Physics2D.Raycast(wallCheck.position, new Vector2(transform.localScale.x, 0), wallCheckDistance, whatIsGround);
    }
    /// <summary>
    /// Impide el funcionamiento del rebote entre paredes
    /// </summary>
    private void CloseWallJump()
    {
        isTouchingWall = Physics2D.Raycast(wallCheck.position, new Vector2(transform.localScale.x, 0), 0, whatIsGround);
    }

    /// <summary>
    /// Comprobamos si puede saltar
    /// </summary>
    private void CheckIfCanJump()
    {
        if (isGrounded && !gettingOffFloor)
        {
            numJumpLeft = 1;
        }
        if (numJumpLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    /// <summary>
    /// Recibe el input para saltar y aplicamos el salto prolongado
    /// </summary>
    private void FinalizeJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeighMultiplier);
    }

    /// <summary>
    /// Saltos desde el suelo y paredes
    /// </summary>
    private void Jump()
    {
        GameManager.instance.sumaTutorial(2);
        if (canJump && !isWallSliding)  //Salto desde el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            gettingOffFloor = true;
            numJumpLeft--;
            Invoke("ResetJumpGetOffCounter", timeToGetOffFloor);
        }
        else if (isWallSliding)   //Wall Hop
        {
            //facingDirection *= -1;
            characterScale = transform.localScale;

            isWallSliding = false;
            characterScale.x *= -1;
            rb.velocity = new Vector2(1, 1);
            rb.AddForce(new Vector2(wallJumpForce * characterScale.x, wallJumpForce), ForceMode2D.Impulse); // quitado "facingDirection" --- Javier
            transform.localScale = characterScale;
            playerIsJumpingOffWall = true;
            Invoke("FinalizeJumpOffWall", wallJumpTimeOffImpulse);
        }
        //Elimino el wallHop y limito el rebote entre paredes a solo una posibilidad
        /*else if ((isWallSliding || isTouchingWall) && movementInputDirection != 0 && canJump)  //Rebote de paredes
        {
            if (Input.GetAxis("Horizontal") <= 0)    //Si mira hacia la izquierda...
            {
                isWallSliding = false;
                numJumpLeft--;
                Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
                rb.AddForce(forceToAdd, ForceMode2D.Impulse);
                Flip();
            }
            else if (Input.GetAxis("Horizontal") >= 0)     //Si mira a la derecha...
            {
                isWallSliding = false;
                numJumpLeft--;
                Vector2 forceToAdd = new Vector2(wallJumpForce * wallHopDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
                rb.AddForce(forceToAdd, ForceMode2D.Impulse);
                Flip();
            }
        }*/
    }

    void ResetJumpGetOffCounter()
    {
        gettingOffFloor = false;
    }

    void FinalizeJumpOffWall()
    {
        playerIsJumpingOffWall = false;
    }

    /// <summary>
    /// Aplica el movimiento si estás en el suelo y lo reduce cuando te estás deslizando
    /// </summary>
    private void ApplyMovement()
    {
        if (!playerIsJumpingOffWall)
        {
            //Si estás en el suelo...
            if (isGrounded)
            {
                rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
                if (rb.velocity.x > 1)
                    GameManager.instance.sumaTutorial(1);
            }
            else if (!isGrounded && !isWallSliding && movementInputDirection != 0)
            {
                Vector2 forceToAdd = new Vector2(movementForceInAir * movementInputDirection, 0);
                rb.AddForce(forceToAdd, ForceMode2D.Impulse);

                if (Mathf.Abs(rb.velocity.x) > movementSpeed)
                {
                    rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
                }
            }
            else if (!isGrounded && !isWallSliding && movementInputDirection == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
            }

            //Si te estás deslizando...
            if (isWallSliding)
            {
                if (rb.velocity.y < -wallSlideSpeed)
                {
                    //Aplicamos fricción
                    rb.velocity = new Vector2(movementSpeed * movementInputDirection, -wallSlideSpeed);
                }
            }
        }
    }

    /// <summary>
    /// Realiza correctamente el Flip del player y comprueba si está andando o no
    /// </summary>
    private void CheckMovementDirection()
    {
        if (!GameManager.instance.GetMenu())
        {
            if (movementInputDirection < 0)
            {
                Flip();
            }
            else if (movementInputDirection > 0)
            {
                Flip();
            }
            if (rb.velocity.x != 0)
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }
        }
    }

    /// <summary>
    /// Flip del player
    /// </summary>
    private void Flip()
    {
        if (!isWallSliding)
        {

            if (movementInputDirection < 0)
            {
                characterScale.x = -1;
            }

            if (movementInputDirection > 0)
            {
                characterScale.x = 1;
            }

            transform.localScale = characterScale;
        }
    }

    /// <summary>
    /// Ayuda para hacer las físicas más visuales
    /// </summary>
    private void OnDrawGizmos()
    {
        //Para dibujar el IsGrounded
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        //Para dibujar el IsWallSliding
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }

    /// <summary>
    /// Si se queda sin vidas se muere
    /// </summary>
    public void reaparecer()
    {
        if (GameManager.instance != null)
        {
            transform.position = spawnpoint;
        }
    }
    /// <summary>
    /// Detecta cuando entra en contacto con un Checkpoint (que no se haya activado antes) y guarda sus coordenadas para poder reaparecer en ellas.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Checkpoint" && collision.GetComponent<Checkpoint>().enabled == true)
        {
            spawnpoint = collision.transform.position;
        }

        // Si el jugador colisiona con una plataforma móvil, pasa a ser hijo de esta, si no, no es hijo de nadie
        if (collision.gameObject.TryGetComponent<PlataformaMovil>(out var plataforma))
            transform.parent = collision.transform;
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent = null;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}