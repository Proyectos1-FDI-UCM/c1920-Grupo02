using UnityEngine;

public class PlataformaTransparente : MonoBehaviour
{
    public BoxCollider2D collider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControllerWallJump>())
        {
            collider.enabled = false;
            Debug.Log("Me he activado");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collider.enabled = true;
    }
}