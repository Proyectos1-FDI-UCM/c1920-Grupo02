using UnityEditor.Rendering;
using UnityEngine;

public class QuitaVida : MonoBehaviour
{
    public int damage;
    public float time = 1;
    private float initialtime;
    private void Awake()
    {
        initialtime = time;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>() != null)
        {
            GameManager.instance.LoseLife(damage);

            //Y haces que parpadee
            collision.gameObject.GetComponent<PlayerRecibeDanyo>().Dañado();
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        time -= Time.deltaTime;
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>() != null && time <= 0)
        {
            GameManager.instance.LoseLife(damage);
            time = initialtime;
        }
          
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        time = initialtime;
    }





}