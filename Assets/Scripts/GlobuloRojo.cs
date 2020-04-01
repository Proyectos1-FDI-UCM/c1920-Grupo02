using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobuloRojo : MonoBehaviour
{
    public int puntos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.UpdateGlobulosRojos(puntos);
            Destroy(this.gameObject);
        }
        else
            Debug.LogError("GameManager no se encuentra en la escena");
    }
}