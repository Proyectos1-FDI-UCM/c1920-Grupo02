using UnityEngine;
public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;

    //Vector resultante que controla el movimiento del dash
    Vector2 dashmovement;

    //Velocidad del movimiento rb.velocity
    public float dashspeed;

    //Velocidad de ejecución del dash
    public float executionSpeed = 0.4f;

    //Gravedad
    float gravity;

    //Cooldown
    float lastTimeOfActivation;
    [SerializeField]
    float cooldown;

    //Animaciones
    Animator animator;

    /*De momento me funcionan bien los valores:
     * 
     * dashspeed = 8
     * executionSpeed = 0.4*/

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        lastTimeOfActivation = -10f;
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Realización del movimiento mientras el dash esté activo
        if(transform.localScale.x==1) rb.velocity = dashmovement * transform.right;
        else rb.velocity = dashmovement * -transform.right;
    }
    private void Update()
    {
        //Contador para el cambio de pastilla
        if (executionSpeed <= 0)    //Si se ha acabado el tiempo...
        {
            enabled = false;        //Se desactiva el dash
            executionSpeed = 0.4f;
        }
        else
            executionSpeed -= Time.deltaTime;
    }
    //Activación del dash
    private void OnEnable()
    {
        if (lastTimeOfActivation < Time.time - cooldown)
        {
            animator.SetTrigger("Dash");
            //Cambio de la capa física de player
            gameObject.layer = 11;   /*La capa física en cuestión debe de:
                                    -Colisionar con el suelo y resto de obstáculos
                                    -No colisionar con disparos o ataques enemigos*/
            rb.gravityScale = 0;
            dashmovement = new Vector2(dashspeed, 0);
            lastTimeOfActivation = Time.time;
        }
        else
        {
            enabled = false;
        }
    }


    private void OnDisable()
    {
        //Cambia la capa física del player a la original
        gameObject.layer = 10;
        rb.gravityScale = gravity;
        dashmovement = new Vector2(0,0);
    }
}