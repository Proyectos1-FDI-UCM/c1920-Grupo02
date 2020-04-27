using UnityEngine;

public class Melee : MonoBehaviour
{
    PlayerInputActions inputActions;

    bool meleeAtacking;

    public GameObject ataque; // prefab a invocar para atacar

    Animator animator;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.AtqMelee.started += ctx => meleeAtacking = true;
        inputActions.PlayerControls.AtqMelee.canceled += ctx => meleeAtacking = false;
        inputActions.PlayerControls.AtqMelee.performed += ctx => meleeAtacking = false;
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (!GameManager.instance.GetMenu())
        {
            if (ataque != null) // si se configuró bien el componente:
            {
                if (meleeAtacking && GameManager.instance.GetPlayerCanAtack()) // si se desea atacar a melee y se puede:
                {
                    if (animator != null)
                        animator.SetTrigger("Melee");
                    if (gameObject.transform.localScale.x == 1) // si el personaje mira a dchas.:
                    {
                        Instantiate<GameObject>(ataque, gameObject.transform.position + new Vector3(0.75f, 0, 0), Quaternion.identity, gameObject.transform); // invocación de prefab
                    }
                    else if (this.gameObject.transform.localScale.x == -1) // si el personaje mira a izdas.:
                    {
                        Instantiate<GameObject>(ataque, gameObject.transform.position + new Vector3(-0.75f, 0, 0), Quaternion.identity, gameObject.transform); // invocación de prefab
                    }
                }
            }
            else print("ERROR: no se configuró vía inspector el prefab de ataque"); // de lo contrario: no se configuró bien el componente
        }
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
// --- Javier