using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobuloRojo : MonoBehaviour
{
    public int puntos;
    public int vidañadida;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.UpdateGlobulosRojos(puntos);
            GameManager.instance.AddLife(vidañadida);
            

            Destroy(this.gameObject);
        }
        else
            Debug.LogError("GameManager no se encuentra en la escena");
    }
}