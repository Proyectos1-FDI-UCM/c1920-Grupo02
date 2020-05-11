using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int numTutorial;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.sumaTutorial(numTutorial);
    }
}
