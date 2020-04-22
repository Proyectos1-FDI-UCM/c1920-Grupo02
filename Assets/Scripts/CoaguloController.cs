using UnityEngine;

/*Máquina de estados del enemigo
    Cede el control al resto de scripts que contiene el GameObject Enemigo
    y sus hijos según lo requiera la situación.
    */

public class CoaguloController : MonoBehaviour
{
    PlayerDetection playerDetection;
    DispararCoagulo disparar;

    //Referencias
    void Start()
    {
        disparar = gameObject.GetComponent<DispararCoagulo>();
        playerDetection = gameObject.GetComponentInChildren<PlayerDetection>();
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