using UnityEngine;

public class ParedBloqueada : MonoBehaviour
{
    //Globulos necesarios para abrir la puerta
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
