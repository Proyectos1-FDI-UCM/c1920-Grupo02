using UnityEngine;

public class SetInitialSpeed : MonoBehaviour
{
    //Velocidad del disparo
    public float initialVelocity = 20;

    //Tiempo que tarda en destruirse
    public float tiempo = 0.2f;

    private Rigidbody2D rb;
    void Start()
    {
        //Cacheamos el rigidbody
        rb = gameObject.GetComponent<Rigidbody2D>();

        //Actualizamos el estado de ataque
        GameManager.instance.UpdateCanAtack(false);

        //Realización del movimiento cuando el disparo está activo
        if (GameManager.instance.GetPlayerLooking() == 1) rb.velocity = transform.right * initialVelocity; // comprobación del estado en el GM --- Javier
        else rb.velocity = transform.right * -initialVelocity;


        Debug.Log(GameManager.instance.GetPlayerLooking());

        Destroy(this.gameObject, tiempo);
    }
    //Al entrar en contacto con algo...
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se destruye
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        GameManager.instance.UpdateCanAtack(true); // actualización del estado de ataque
    }
}