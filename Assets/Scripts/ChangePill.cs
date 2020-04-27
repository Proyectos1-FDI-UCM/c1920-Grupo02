using UnityEngine;

public class ChangePill : MonoBehaviour
{
    PlayerInputActions inputActions;

    private bool nextCharacter;
    private bool prevCharacter;
    private bool shootOrDash;

    //Contador para cambiar de pastilla
    public float contador = 0;

    private SpriteRenderer spriteRenderer;
    public Sprite[] pastis = new Sprite[3]; //Cojo los sprites de las pastillas
    private int pastilla = 1; //Comprueba que pastilla somos (Empezamos con Ibuprofeno)
    bool cambio = false;    //Comprueba que podemos cambiar de pastilla

    public GameObject fire; //Sprite de la bala
    public Transform firePoint; //Lugar de Spawn

    Dash dash;

    //Animaciones
    private Animator animator;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.NextCharacter.started += ctx => nextCharacter = true;
        inputActions.PlayerControls.NextCharacter.canceled += ctx => nextCharacter = false;
        inputActions.PlayerControls.PrevCharacter.started += ctx => prevCharacter = true;
        inputActions.PlayerControls.PrevCharacter.canceled += ctx => prevCharacter = false;
        inputActions.PlayerControls.ShootOrDash.started += ctx => shootOrDash = true;
        inputActions.PlayerControls.ShootOrDash.canceled += ctx => shootOrDash = false;
        animator = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        //Cacheo
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        dash = gameObject.GetComponent<Dash>();
    }
    void Update()
    {
        //Contador
        if (GameManager.instance != null)
        {
            if (contador <= 0)
            {
                contador = 0;
                GameManager.instance.ColorPills();
            }
            else
            {
                contador -= Time.deltaTime;
                GameManager.instance.Contador(contador);
            }
        }
        else
            Debug.LogError("GameManager no se encuentra en la escena");

        //pills[0] = Homeopatica
        //pills[1] = Ibuprofeno
        //pills[2] = Extasis

        //Disparo       Al empezar con el ibuprofeno puedes disparar desde el inicio
        if (shootOrDash && pastilla == 1 && GameManager.instance.GetPlayerCanAtack()) //Si se pulsas una tecla de disparo y eres Ibuprofeno...
            Shoot(); //Dispara

        if (cambio) //Si has recogido el powerUp...
        {
            if (GameManager.instance != null)
            {
                //Puedes cambiar de pastilla
                if (((prevCharacter && (pastilla == 0)) || ((nextCharacter && (pastilla == 1)))) && contador == 0)   //Ibuprofeno
                {
                    Debug.Log("Pastilla 3");
                    pastilla = 2;
                    spriteRenderer.sprite = pastis[pastilla];
                    contador = 10;
                    //GameManager.instance.DesactivatePill();
                    GameManager.instance.ActualPill(pastilla);
                }
                else if (((prevCharacter && (pastilla == 1)) || ((nextCharacter && (pastilla == 2)))) && contador == 0)   //Homeopatica
                {
                    GameManager.instance.sumaTutorial(6);   //Tutorial
                    Debug.Log("Pastilla 1");
                    pastilla = 0;
                    spriteRenderer.sprite = pastis[pastilla];
                    contador = 10;
                    //GameManager.instance.DesactivatePill();
                    GameManager.instance.ActualPill(pastilla);

                }
                else if (((prevCharacter && (pastilla == 2)) || ((nextCharacter && (pastilla == 0)))) && contador == 0)  //Extasis
                {
                    GameManager.instance.sumaTutorial(5);   //Tutorial
                    Debug.Log("Pastilla 2");
                    pastilla = 1;
                    spriteRenderer.sprite = pastis[pastilla];
                    contador = 10;
                    //GameManager.instance.DesactivatePill();
                    GameManager.instance.ActualPill(pastilla);

                }
            }
            else
            {
                Debug.LogError("GameManager no se encuentra en la escena");
            }
            //Dash
            if (shootOrDash && pastilla == 2) //Si se pulsas una tecla de disparo y eres Extasis...
                dash.enabled = true;

        }
    }
    /// <summary>
    /// Dispara una bala
    /// </summary>
    void Shoot()
    {
        if (animator != null)
            animator.SetTrigger("Shoot");
        //La primera vez que dispara lo manda al GM para continuar con el tutorial
        GameManager.instance.sumaTutorial(3);
        if (!GameManager.instance.GetMenu()) Instantiate<GameObject>(fire, firePoint.position, firePoint.rotation); //Spawn de disparo
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ActivatePill>())
        {
            cambio = true;
            //IMPLEMENTAR TEXTO AYUDA
        }
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