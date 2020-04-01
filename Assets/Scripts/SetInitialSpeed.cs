using UnityEngine;

public class SetInitialSpeed : MonoBehaviour
{
    public float initialVelocity = 15; //Velocidad del disparo
    private Rigidbody2D rb;
    public float tiempo;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        GameManager.instance.UpdateCanAtack(false); // actualización del estado de ataque

        //Realización del movimiento cuando el disparo está activoç
        if (GameManager.instance.GetPlayerLooking() ==1) rb.velocity = transform.right * initialVelocity; // comprobación del estado en el GM --- Javier
        else rb.velocity = -transform.right * initialVelocity;

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