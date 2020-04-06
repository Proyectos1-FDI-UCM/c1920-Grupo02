using UnityEngine;

/* Tenia
 * Se mueve hacia adelante a una gran velocidad culminando en un mordisco
 */

/*Pequeña nota de recordatorio de funcionamiento
 * Este script es activado por TeniaController cuando el jugador
 * se encuentra en su rango de visión durante demasiado tiempo
 * El script es desactivado por TeniaController al producirse uno de los siguientes casos:
 * 
 *      -La tenia se encuentra con un limite de patrullaje
 *      -Pasa un cierto número configurable de segundos
 * 
 * Al ser activado, el script determina la dirección en la que la Tenia estaba mirando
 * Mientras esté activado la Tenia se desplazará en esa dirección a una velocidad configurable
 * Al ser desactivado Spawneará un ataque a melee en su boca con un rango corto
 */

public class Enemy_MordiscoAbominable : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    int direction;
    QuitaVida quitavida;
    int initialDamage;
    public int dañoMordisco;
    public float dashSpeed;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        quitavida = gameObject.GetComponent<QuitaVida>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * dashSpeed, 0);
    }

    private void OnEnable()
    {
        if (spriteRenderer.flipX)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        initialDamage = quitavida.damage;
        quitavida.damage = dañoMordisco;
    }
    private void OnDisable()
    {
        rb.velocity = new Vector2(0, 0);
        quitavida.damage = initialDamage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            gameObject.GetComponent<Enemy_MordiscoAbominable>().enabled = false;
        }
    }
}