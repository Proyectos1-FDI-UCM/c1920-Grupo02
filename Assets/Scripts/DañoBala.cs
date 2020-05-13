using UnityEngine;

public class DañoBala : MonoBehaviour
{
    public int daño = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>() != null)
        {
            GameManager.instance.LoseLife(1);

            //Y haces que parpadee
            collision.gameObject.GetComponent<PlayerRecibeDanyo>().Dañado();
        }
        Destroy(this.gameObject);
    }
}