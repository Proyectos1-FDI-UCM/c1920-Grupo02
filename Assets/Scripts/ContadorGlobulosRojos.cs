using UnityEngine.UI;
using UnityEngine;

public class ContadorGlobulosRojos : MonoBehaviour
{
    private Text contador;
    private void Awake()
    {
        contador = gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        contador.text = GameManager.instance.ReturnGlobulosRojos() + "";
    }
}
