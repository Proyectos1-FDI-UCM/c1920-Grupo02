using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bajarPlataforma : MonoBehaviour
{
    public BoxCollider2D collider;

    PlayerInputActions inputActions;
    bool descense;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Descenso.started += ctx => descense = true;
        inputActions.PlayerControls.Descenso.canceled += ctx => descense = false;
    }
    void Update()
    {
        if (!GameManager.instance.GetMenu())
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControllerWallJump>())
        {
            Debug.Log("e");
        }
        if (descense)
        {
            collider.enabled = false;
            Debug.Log("AAAAAAAA");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collider.enabled = true;
        Debug.Log("Gracias por venir");
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
