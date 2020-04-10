using UnityEngine;

public class BalaSpeed : MonoBehaviour
{
    public float initialVelocity = 15; //Velocidad del disparo
    private Rigidbody2D rb;
    public float tiempo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Realización del movimiento cuando el disparo está activo

        rb.velocity = new Vector2(initialVelocity, 0);
        Destroy(this.gameObject, tiempo); // Deestruccion del Objeto a los segundos 
        
    }
   
}
