using UnityEngine;

public class QuitaVida : MonoBehaviour
{
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
            GameManager.instance.LoseLife(damage);
    }
}