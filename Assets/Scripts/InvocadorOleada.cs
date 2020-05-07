using UnityEngine;

public class InvocadorOleada : MonoBehaviour
{
    public int rotate;
    public float contador;
    public GameObject blood;
    private float time;
    private void OnEnable()
    {

        //Rotas el GO...
        transform.rotation = Quaternion.Euler(0,0,rotate);

        //Reestablecemos el contador
        time = contador;

        //Comienza la animacion
        //Falta por hacer creo
    }

    void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
        {
            Instantiate(blood,transform.position + transform.right.normalized*1.5f,transform.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
