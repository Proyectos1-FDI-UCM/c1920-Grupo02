using UnityEngine;

public class InvocadorOleada : MonoBehaviour
{
    public bool rotate;
    public float contador;
    public GameObject blood;
    private float time;
    private Transform wall;
    private Vector3 aux;
    private void Awake()
    {
        wall = gameObject.GetComponent<Transform>();
    }
    private void OnEnable()
    {
        //Si quieres rotar el GO...
        if (rotate)
        {
            wall.rotation = Quaternion.Euler(0, 180f, 0);

            //Rotas el GO...
            transform.rotation = wall.rotation;

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
