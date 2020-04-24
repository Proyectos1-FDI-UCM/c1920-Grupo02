using UnityEngine;

public class ParedBloqueada : MonoBehaviour
{
    private TextMesh numGlobulos;

    //Globulos necesarios para abrir la puerta
    public int globulosBlancosNecesarios;

    private void Start()
    {
        numGlobulos = gameObject.GetComponentInChildren<TextMesh>();
        //Si ha cogido el texto correctamente
        if (numGlobulos != null)
            //Te pone los numeros de globulos necesarios para desbloquear la puerta
            numGlobulos.text = globulosBlancosNecesarios + "";
        else
            Debug.LogError("Texto no existente");        
    }

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
