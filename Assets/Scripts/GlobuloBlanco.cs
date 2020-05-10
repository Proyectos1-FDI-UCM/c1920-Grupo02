using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobuloBlanco : MonoBehaviour
{
    public int puntos;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (GameManager.instance != null)
    //    {
    //        GameManager.instance.UpdateGlobulosBlancos(puntos);
    //        Destroy(this.gameObject);
    //    }
    //    else
    //        Debug.LogError("GameManager no se encuentra en la escena");
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>())   //Si el jugador la toca...
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.UpdateGlobulosBlancos(puntos);
                Destroy(this.gameObject);
            }
            else
                Debug.LogError("GameManager no se encuentra en la escena");
        }
    }
}