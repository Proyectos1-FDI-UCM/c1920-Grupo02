using UnityEngine;

public class SpeedBala : MonoBehaviour
{
    public float initialVelocity = 15; //Velocidad del disparo
    private Rigidbody2D rb;
    public float tiempo;
    public GameObject enemy2sprite;
   
    void Start()
    {
        GameObject Body = enemy2sprite.transform.GetChild(0).gameObject;
        rb = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer enemigo = Body.GetComponent<SpriteRenderer>();


        //Realización del movimiento cuando el disparo está activo
        if (enemigo.flipX== false) rb.velocity = transform.right * initialVelocity; // comprobación de done mira el enemigo
        else rb.velocity = -transform.right * initialVelocity;

        Destroy(this.gameObject, tiempo);
    }
    //Al entrar en contacto con algo...
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se destruye
        Destroy(this.gameObject);
    }
}
