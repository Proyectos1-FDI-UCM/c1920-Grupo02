using UnityEngine;

public class GranCoaguloLife : MonoBehaviour
{
    private DisparoDeSangre disparo;

    [SerializeField]
    private int parts = 3;

    //Ads
    private GameObject wave1;
    private GameObject wave2;
    private GameObject oleadaDanina1;
    private GameObject oleadaDanina2;
    private GameObject oleadaDanina3;
    private GameObject oleadaDanina4;

    private bool inCombat;
    private int numOleadasDeSangre;
    private float initialTime;
    [SerializeField]
    private float timerPrimeraOleadaDeSangre;
    [SerializeField]
    private float timerSegundaOleadaDeSangre;
    [SerializeField]
    private float timerTerceraOleadaDeSangre;
    [SerializeField]
    private float timerCuartaOleadaDeSangre;
    [SerializeField]
    private GameObject door;

    private void Awake()
    {
        inCombat = false;
        numOleadasDeSangre = 0;
        disparo = gameObject.GetComponent<DisparoDeSangre>();
        wave1 = gameObject.GetComponentInChildren<GranCoagulo_FirstAddWave>().gameObject;
        wave1.SetActive(false);
        wave2 = gameObject.GetComponentInChildren<GranCoagulo_SecondAddWave>().gameObject;
        wave2.SetActive(false);
        oleadaDanina1 = gameObject.GetComponentInChildren<GranCoagulo_OleadaDanina1>().gameObject;
        oleadaDanina1.SetActive(false);
        numOleadasDeSangre++;
        oleadaDanina2 = gameObject.GetComponentInChildren<GranCoagulo_OleadaDanina2>().gameObject;
        oleadaDanina2.SetActive(false);
        numOleadasDeSangre++;
        oleadaDanina3 = gameObject.GetComponentInChildren<GranCoagulo_OleadaDanina3>().gameObject;
        oleadaDanina3.SetActive(false);
        numOleadasDeSangre++;
        oleadaDanina4 = gameObject.GetComponentInChildren<GranCoagulo_OleadaDanina4>().gameObject;
        oleadaDanina4.SetActive(false);
        numOleadasDeSangre++;
    }

    private void Update()
    {
        //FXManager.PlaySound("CoaguloEnergia");
        if (inCombat)
        {
            if (numOleadasDeSangre == 4 && Time.time > initialTime + timerPrimeraOleadaDeSangre)
            {
                oleadaDanina1.SetActive(true);
                numOleadasDeSangre--;
            }
            else
            {
                if (numOleadasDeSangre == 3 && Time.time > initialTime + timerSegundaOleadaDeSangre)
                {
                    oleadaDanina2.SetActive(true);
                    numOleadasDeSangre--;
                }
                else
                {
                    if (numOleadasDeSangre == 2 && Time.time > initialTime + timerTerceraOleadaDeSangre)
                    {
                        oleadaDanina3.SetActive(true);
                        numOleadasDeSangre--;
                    }
                    else
                    {
                        if (numOleadasDeSangre == 1 && Time.time > initialTime + timerCuartaOleadaDeSangre)
                        {
                            oleadaDanina4.SetActive(true);
                            numOleadasDeSangre--;
                        }
                    }
                }
            }
        }
    }

    public void PartLost()
    {
        parts--;
        if (parts == 0)
        {
            FXManager.PlaySound("PuertaDesbloqueable");
            Destroy(door);
            Destroy(gameObject);
        }
        else
        {
            if (parts == 2)
            {
                wave1.SetActive(true);
            }
            else
            {
                if (parts == 1)
                {
                    wave2.SetActive(true);
                }
            }
            disparo.tiempo *= 2;
        }
    }
    public void StartCombat()
    {
        inCombat = true;
        initialTime = Time.time;
    }
}