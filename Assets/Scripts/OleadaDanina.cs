using UnityEngine;

public class OleadaDanina : MonoBehaviour
{
    public float velocidad = 10;
    public int damage;
    float initialTime;
    public float timeBeforeDestroy;

    private Rigidbody2D rb;
    private void Start()
    {
        //Cacheamos el rigidbody
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * velocidad;
        initialTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > initialTime + timeBeforeDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si se choca con el jugador
        if (other.gameObject.GetComponent<PlayerControllerWallJump>())
        {
            //Le hace mucho daño
            GameManager.instance.LoseLife(damage);

            //Y haces que parpadee
            other.gameObject.GetComponent<PlayerRecibeDanyo>().Dañado();
        }

        //Se destruye
        Destroy(this.gameObject);
    }
}
