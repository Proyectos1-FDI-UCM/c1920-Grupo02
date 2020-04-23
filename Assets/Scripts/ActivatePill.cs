using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>())   //Si el jugador la toca...
        {
            Destroy(this.gameObject);
            if(GameManager.instance != null)
            {
                GameManager.instance.ActualPill(1);
                collision.gameObject.GetComponent<tutorial>();
            }
        }
    }
}
