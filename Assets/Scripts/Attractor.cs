using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Attractor : MonoBehaviour
{
    public float Speed = 10;
    private bool isTouched = false;
    private Vector3 player;
    private CircleCollider2D cd2;

    public float radius = 0.75f;

    private void Start()
    {
        cd2 = GetComponent <CircleCollider2D> ();
        cd2.radius = radius;
        cd2.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>() != null)
        {
            player = collision.transform.position;
            isTouched = true;
            //cd2.enabled = false;
            
        }
    }

    private void Update()
    {
        if (isTouched)
        {
            transform.position = Vector2.MoveTowards(transform.position, player, Speed * Time.deltaTime);
            transform.Rotate(Vector3.forward * 5);
        }
    }
}
