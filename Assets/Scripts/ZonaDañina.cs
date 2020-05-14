using UnityEngine;

public class ZonaDañina : MonoBehaviour
{
    //Variable que indica cada cuanto se le quita vida al jugador 
    private float timer = 0; 
 
    //Si te quedas en la zona dañina...
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Si el timer no ha llegado a 0...
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>() != null && timer>0)
        {
            //Lo vas restando
            timer -=Time.deltaTime;
        }
        //Si el timer ya está en 0...
        else if (collision.gameObject.GetComponent<PlayerControllerWallJump>() != null && timer <= 0) 
        {
            //Restas una vida
            GameManager.instance.LoseLife(1);

            //haces que parpadee
            collision.gameObject.GetComponent<PlayerRecibeDanyo>().Dañado();

            //Y reseteas el timer
            timer = 0.3f;
        }
    }
    //Cuando te sales de la zona dañina...
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Reseteas el timer para que vuelva a hacer daño
        timer = 0;
    }
}
