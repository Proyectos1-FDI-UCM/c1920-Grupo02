using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTransparente : MonoBehaviour
{
    public GameObject plataforma;
    private BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = plataforma.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collider.enabled = false;
        Debug.Log("Me he activado");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collider.enabled = true;
    }
}
