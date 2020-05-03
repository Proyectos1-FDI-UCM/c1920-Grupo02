using UnityEngine;

public class OleadaDanina : MonoBehaviour
{
    public float velocidad = 10;
    public int damage;

    private Rigidbody2D rb;
    private void Start()
    {
        //Cacheamos el rigidbody
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * velocidad;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si se choca con el jugador
        if (other.gameObject.GetComponent<PlayerControllerWallJump>())
        {
            //Le hace mucho daño
            GameManager.instance.LoseLife(damage);
        }

        //Se destruye
        Destroy(this.gameObject);
    }
}
