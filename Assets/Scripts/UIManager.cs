using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] pastillasUI;  //Interfaz del cambio de pastilla
    public Text time;            //Contador para el cambio de pastilla

    public Image[] hearts; //Corazon lleno
    int maxLife;    //Vida máxima

    //Interfaz glóbulos
    public Text globulosRojosUI;
    public Text globulosBlancosUI;

    void Start()
    {
        //Desactivamos todo
        pastillasUI[0].enabled = false;
        pastillasUI[1].enabled = false;
        pastillasUI[2].enabled = false;
        time.enabled = false;


        maxLife = hearts.Length;    //Establecemos la çvida máxima
        GameManager.instance.SetUIManager(this);
    }

    //Interfaz de la vida
    public void LifeCount(int life)
    {
        if (life > 0)
        {
            for (int i = maxLife - 1; i >= life; i--)
            {
                hearts[i].enabled = false;
            }
            for (int i = 0; i < life; i++)  //Para recargar la vida en caso de sumarle corazones
            {
                hearts[i].enabled = true;
            }
        }
        else
        {
            for (int i = maxLife - 1; i >= 0; i--)
                hearts[i].enabled = false;
        }
    }
    /// <summary>
    /// Actualiza la puntuación del jugador
    /// </summary>
    /// <param name="points"></param>
    public void UpdateScore(int points)
    {
        //ScoreText.text = points.ToString();       (es mejor scoretext.tect = "" + points; att.Samuel)
    }
    /// <summary>
    /// Desactiva la imagen de la pastilla de la interfaz según cual seas
    /// </summary>
    /// <param name="pastilla"></param>
    public void PillChange(int pastilla)     //Muestra las pastillas que hay disponibles
    {
        pastillasUI[0].enabled = true;
        pastillasUI[1].enabled = true;
        pastillasUI[2].enabled = true;
        //0 = Homeopatica
        //1 = Ibuprofeno
        //2 = Extasis
        if (pastilla == 0)
        {
            pastillasUI[0].color = new Color(1,1,1);
            pastillasUI[1].color = new Color(0.5f, 0.5f, 0.5f);
            pastillasUI[2].color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if (pastilla == 1)
        {
            pastillasUI[0].color = new Color(0.5f, 0.5f, 0.5f);
            pastillasUI[1].color = new Color(1, 1, 1);
            pastillasUI[2].color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if (pastilla == 2)
        {
            pastillasUI[0].color = new Color(0.5f, 0.5f, 0.5f);
            pastillasUI[1].color = new Color(0.5f, 0.5f, 0.5f);
            pastillasUI[2].color = new Color(1, 1, 1);
        }
    }
    /// <summary>
    /// Desactiva todas las pastillas de la interfaz hasta que el contador llegue a 0
    /// </summary>
    public void ColorfulPill()
    {
        pastillasUI[0].color = new Color(1, 1, 1);
        pastillasUI[1].color = new Color(1, 1, 1);
        pastillasUI[2].color = new Color(1, 1, 1);
    }
    /// <summary>
    /// Muestra en pantalla el contador de espera del cambio de pastilla
    /// </summary>
    /// <param name="contador"></param>
    public void Timing(float contador)
    {
        time.enabled = true;
        int tiempo = (int)contador;
        time.text = (tiempo + "");
        if (tiempo == 0)
            time.enabled = false;
    }
    /// <summary>
    /// Muestra en pantalla el numero de globulos rojos que posea el jugador
    /// </summary>
    /// <param name="globulos"></param>
    public void UpdateGlobulosRojosUI(int globulos)
    {
        globulosRojosUI.text = globulos + "";
    }
    /// <summary>
    /// Muestra en pantalla el numero de globulos blancos que posea el jugador
    /// </summary>
    /// <param name="globulos"></param>
    public void UpdateGlobulosBlancosUI(int globulos)
    {
        globulosBlancosUI.text = globulos + "";
    }
}
