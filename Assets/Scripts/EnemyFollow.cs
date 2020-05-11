using UnityEngine;

/*Mueve al body del enemigo en la dirección dada por PlayerDetection
 * También permite la configuración de la velocidad mediante followSpeed
 */

public class EnemyFollow : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerDetection detection;
    private SpriteRenderer spriteRenderer;
    public float followSpeed;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        detection = gameObject.GetComponentInChildren<PlayerDetection>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(detection.direccion * followSpeed, 0);
        if (detection.direccion > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            if (detection.direccion < 0)
                spriteRenderer.flipX = true;
        }
    }

    private void OnDisable()
    {
        rb.velocity = new Vector2(0, 0);
    }
}