using UnityEngine;

public class BalaSpeed2 : MonoBehaviour
{
    public float initialVelocity = 15; //Velocidad del disparo
    private Rigidbody2D rb;
    public float tiempo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Realización del movimiento cuando el disparo está activo

        rb.velocity = transform.right * initialVelocity;
        Destroy(gameObject, tiempo); // Deestruccion del Objeto a los segundos 
    }
}