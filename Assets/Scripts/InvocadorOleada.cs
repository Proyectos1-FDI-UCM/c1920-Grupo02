using UnityEngine;

public class InvocadorOleada : MonoBehaviour
{
    public bool rotate;
    public float contador;
    public GameObject blood;
    private float time;

    private Vector3 aux;
    private void OnEnable()
    {
        //Si quieres rotar el GO...
        if (rotate)
        {
            //Rotas el GO...
            transform.Rotate(0, 180, 0);

            aux = new Vector3(-2, 0);
        }
        else
            aux = new Vector3(2, 0);


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
            Instantiate(blood,transform.position + aux,transform.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
