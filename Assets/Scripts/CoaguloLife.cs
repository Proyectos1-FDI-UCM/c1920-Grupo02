using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoaguloLife : MonoBehaviour
{
    private DispararCoagulo disparo;
    private int life = 2;

    private void Awake()
    {
        disparo = gameObject.GetComponent<DispararCoagulo>();
    }
    public void PartLost()
    {
        life--;
        if (life == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            //Cambiar disparo
        }
    }
}