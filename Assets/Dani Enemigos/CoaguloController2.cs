using UnityEngine;

/*Máquina de estados del enemigo
    Cede el control al resto de scripts que contiene el GameObject Enemigo
    y sus hijos según lo requiera la situación.
    */

public class CoaguloController2 : MonoBehaviour
{
    Coagulo_PlayerDetection playerDetection;
    DispararCoagulo2 disparar;

    //Referencias
    void Start()
    {
        disparar = gameObject.GetComponent<DispararCoagulo2>();
        playerDetection = gameObject.GetComponentInChildren<Coagulo_PlayerDetection>();
    }

    private void Update()
    {
        if (playerDetection.direccion == 0)
        {
            disparar.enabled = false;
        }
        else
        {
            disparar.enabled = true;
        }
    }
}