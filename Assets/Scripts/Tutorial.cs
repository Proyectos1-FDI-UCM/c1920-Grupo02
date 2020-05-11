using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int numTutorial;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>())
        {
            GameManager.instance.sumaTutorial(numTutorial);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerWallJump>())
            GameManager.instance.sumaTutorial(-1);
    }
}
