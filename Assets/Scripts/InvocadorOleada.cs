using UnityEngine;

public class InvocadorOleada : MonoBehaviour
{
    public float contador;
    public GameObject blood;
    private Transform bloodPoint;
    private void OnEnable()
    {
        bloodPoint = this.transform;
        contador = 3;
        //Comienza la animacion
    }

    void Update()
    {
        if (contador > 0)
            contador -= Time.deltaTime;
        else
        {
            Instantiate<GameObject>(blood,bloodPoint.position,bloodPoint.rotation);
            this.gameObject.SetActive(false);
        }
    }
}
