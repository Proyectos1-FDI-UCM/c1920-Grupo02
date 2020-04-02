using UnityEngine;

public class SpeedDcha : MonoBehaviour
{
    public float initialVelocity = 15; //Velocidad del disparo
    private Rigidbody2D rb;
    public float tiempo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, tiempo); // Deestruccion del Objeto a los segundos 
    }
    void FixedUpdate()
    {
        //Realización del movimiento cuando el disparo está activo
        rb.velocity = new Vector2(initialVelocity,0);

    }

}
