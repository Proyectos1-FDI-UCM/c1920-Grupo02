using UnityEngine;

public class Tenia_StopOnCollisioonPlayer : MonoBehaviour
{
    TeniaController controller;

    private void Awake()
    {
        controller = gameObject.GetComponentInParent<TeniaController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>()!=null)
            controller.CollidedWithPlayer();
    }
}