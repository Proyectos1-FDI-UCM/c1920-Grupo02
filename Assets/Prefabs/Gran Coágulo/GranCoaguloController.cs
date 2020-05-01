using UnityEngine;

/*Máquina de estados del enemigo
    Cede el control al resto de scripts que contiene el GameObject Enemigo
    y sus hijos según lo requiera la situación.
    */

public class GranCoaguloController : MonoBehaviour
{
    Coagulo_PlayerDetection playerDetection;
    DisparoDeSangre disparar;

    void Start()
    {
        disparar = gameObject.GetComponent<DisparoDeSangre>();
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