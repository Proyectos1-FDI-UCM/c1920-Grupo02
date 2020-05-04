using UnityEngine;

public class InvocadorOleada : MonoBehaviour
{
    public bool rotate;
    public float contador;
    public GameObject blood;
    private float time;
    private void OnEnable()
    {
        if (rotate)
            transform.Rotate(0, 180, 0);
        time = contador;
        //Comienza la animacion
    }

    void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
        {
            Instantiate<GameObject>(blood,transform.position,transform.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
