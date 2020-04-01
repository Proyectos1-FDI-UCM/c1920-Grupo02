using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedBloqueada : MonoBehaviour
{
    public int globulosBlancosNecesarios;
    private void Update()
    {
        //Si tienes los globulos blancos necesarios...
        if (globulosBlancosNecesarios == GameManager.instance.ReturnGlobulosBlancos())
        {
            //La puerta se "abre"
            Destroy(this.gameObject);
        }
    }
}
