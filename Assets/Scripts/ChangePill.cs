using UnityEngine;

public class ChangePill : MonoBehaviour
{
    //Contador para cambiar de pastilla
    public float contador = 0;

    private SpriteRenderer spriteRenderer;
    public Sprite[] pastis = new Sprite[3]; //Cojo los sprites de las pastillas
    private int pastilla = 1; //Comprueba que pastilla somos (Empezamos con Ibuprofeno)
    bool cambio = false;    //Comprueba que podemos cambiar de pastilla

    public GameObject fire; //Sprite de la bala
    public Transform firePoint; //Lugar de Spawn

    Dash dash;
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
                GameManager.instance.ActualPill(pastilla);
                contador = 0;
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
        if (Input.GetButtonDown("Dash | At. ranged") && pastilla == 1 && GameManager.instance.GetPlayerCanAtack()) //Si se pulsas una tecla de disparo y eres Ibuprofeno...
            Shoot(); //Dispara

        if (cambio) //Si has recogido el powerUp...
        {
            if (GameManager.instance != null)
            {
                //Puedes cambiar de pastilla
                if (((Input.GetButtonDown("PrevCharacter") && (pastilla == 0)) || ((Input.GetButtonDown("NextCharacter") && (pastilla == 1)))) && contador == 0)   //Ibuprofeno
                {
                    Debug.Log("Pastilla 3");
                    pastilla = 2;
                    spriteRenderer.sprite = pastis[pastilla];
                    contador = 10;
                    GameManager.instance.DesactivatePill();
                }
                else if (((Input.GetButtonDown("PrevCharacter") && (pastilla == 1)) || ((Input.GetButtonDown("NextCharacter") && (pastilla == 2)))) && contador == 0)   //Homeopatica
                {
                    Debug.Log("Pastilla 1");
                    pastilla = 0;
                    spriteRenderer.sprite = pastis[pastilla];
                    contador = 10;
                    GameManager.instance.DesactivatePill();
                }
                else if (((Input.GetButtonDown("PrevCharacter") && (pastilla == 2)) || ((Input.GetButtonDown("NextCharacter") && (pastilla == 0)))) && contador == 0)  //Extasis
                {
                    Debug.Log("Pastilla 2");
                    pastilla = 1;
                    spriteRenderer.sprite = pastis[pastilla];
                    contador = 10;
                    GameManager.instance.DesactivatePill();
                }
            }
            else
            {
                Debug.LogError("GameManager no se encuentra en la escena");
            }
            //Dash
            if (Input.GetButtonDown("Dash | At. ranged") && pastilla == 2) //Si se pulsas una tecla de disparo y eres Extasis...
                dash.enabled = true;

        }
    }
    /// <summary>
    /// Dispara una bala
    /// </summary>
    void Shoot()
    {
        if (!GameManager.instance.GetMenu()) Instantiate<GameObject>(fire, firePoint.position, firePoint.rotation); //Spawn de disparo
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ActivatePill>())
        {
            cambio = true;
        }
    }
}
