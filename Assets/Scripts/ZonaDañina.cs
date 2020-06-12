using UnityEngine;

public class ZonaDañina : MonoBehaviour
{
    //Variable que indica cada cuanto se le quita vida al jugador 
    private float timer = 0;
    private bool inTouch;
    int parpadeo = 0;
    private void Update()
    {
        //Si te quedas en la zona dañina...
        if (inTouch&&timer>0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            //Restas una vida
            GameManager.instance.LoseLife(1);

            parpadeo++;
            //Y reseteas el timer
            timer = 0.3f;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        inTouch = true;
        timer = 0;
        //haces que parpadee
        collision.gameObject.GetComponent<PlayerRecibeDanyo>().Dañado();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (parpadeo > 0)
        {
            //haces que parpadee
            collision.gameObject.GetComponent<PlayerRecibeDanyo>().Dañado();
            parpadeo--;
        }
    }
    //Cuando te sales de la zona dañina...
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Reseteas el timer para que vuelva a hacer daño
        timer = 0;
        inTouch = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTouch = true;
        timer = 0;
        //haces que parpadee
        collision.gameObject.GetComponent<PlayerRecibeDanyo>().Dañado();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (parpadeo > 0)
        {
            //haces que parpadee
            collision.gameObject.GetComponent<PlayerRecibeDanyo>().Dañado();
            parpadeo--;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Reseteas el timer para que vuelva a hacer daño
        timer = 0;
        inTouch = false;
    }
}