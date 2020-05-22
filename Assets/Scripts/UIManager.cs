using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] pastillasUI;  //Interfaz del cambio de pastilla
    public Text time;            //Contador para el cambio de pastilla
    public GameObject arrows;

    public Image[] hearts; //Corazon lleno
    int maxLife;    //Vida máxima

    //Interfaz glóbulos
    public Text globulosRojosUI;
    public Text globulosBlancosUI;

    //Variables necesaria para el Reroll de las pastillas
    private Vector2 auxIbuprofeno;
    private Vector2 auxHomeopatica;
    private Vector2 auxExtasis;

    //Variables necesarias para el tutorial
    public Image tutorialPhoto;
    public Image[] diagramaTutorial;
    int tutorialHecho = -1;
    float aparecer;
    Scene currentScene;
    void Start()
    {
        //Cacheamos
        auxHomeopatica = pastillasUI[0].transform.position;
        auxIbuprofeno = pastillasUI[1].transform.position;
        auxExtasis = pastillasUI[2].transform.position;

        currentScene = SceneManager.GetActiveScene();

        //Desactivamos todo
        pastillasUI[0].enabled = false;
        pastillasUI[1].enabled = false;
        pastillasUI[2].enabled = false;
        time.enabled = false;
        arrows.SetActive(false);


        maxLife = hearts.Length;    //Establecemos la çvida máxima
        GameManager.instance.SetUIManager(this);
    }
    private void Update()
    {
        if(currentScene.name == "Tutorial")
        {
            //Transicion de aparicion
            if (aparecer <= 1)
            {
                aparecer += Time.deltaTime;
                tutorialPhoto.color = new Color(1, 1, 1, aparecer);
            }
        }
    }
    public void TutorialTrigger(int num)
    {
        if (num == 0&& tutorialHecho == -1)
        {
            aparecer = 0;
            tutorialPhoto = diagramaTutorial[num];
            tutorialPhoto.enabled = true;
            tutorialHecho = 0;
        }
        else if (num == 1 && tutorialHecho ==0)
        {
            aparecer = 0;
            tutorialPhoto.sprite = diagramaTutorial[num].sprite;
            tutorialHecho = 1;
        }
        else if (num == 2 && tutorialHecho == 1)
        {
            aparecer = 0;
            tutorialPhoto.sprite = diagramaTutorial[num].sprite;
            tutorialHecho = 2;
        }
        else if (num == 3 && tutorialHecho == 2)
        {
            aparecer = 0;
            tutorialPhoto.sprite = diagramaTutorial[num].sprite;
            tutorialHecho = 3;
        }
        else if (num == 4 && tutorialHecho == 3)
        {
            aparecer = 0;
            tutorialPhoto.sprite = diagramaTutorial[num].sprite;
            tutorialHecho = 4;
        }
        else if (num == 5 && tutorialHecho == 4)
        {
            aparecer = 0;
            tutorialPhoto.sprite = diagramaTutorial[num].sprite;
            tutorialHecho = 5;
        }
        else if (num == 6 && tutorialHecho == 5)
        {
            aparecer = 0;
            tutorialPhoto.sprite = diagramaTutorial[num].sprite;
            tutorialHecho = 6;
        }
        else if (num == 7 && tutorialHecho == 6)
        {
            aparecer = 0;
            tutorialPhoto.sprite = diagramaTutorial[num].sprite;
            tutorialHecho = 7;
        }
        else if(num==8)
            tutorialPhoto.enabled = false;

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
    public void UpdateLife(int vida)
    {
        for (int i = 0; i < vida; i++)  //Para recargar la vida en caso de sumarle corazones
        {
            hearts[i].enabled = true;
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
        arrows.SetActive(true);

        //0 = Homeopatica
        //1 = Ibuprofeno
        //2 = Extasis
        if (pastilla == 0)
        {
            pastillasUI[0].transform.position = auxIbuprofeno;
            pastillasUI[1].transform.position = auxExtasis;
            pastillasUI[2].transform.position = auxHomeopatica;

            pastillasUI[0].color = new Color(1, 1, 1);
            pastillasUI[1].color = new Color(0.5f, 0.5f, 0.5f);
            pastillasUI[2].color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if (pastilla == 1)
        {
            pastillasUI[0].transform.position = auxHomeopatica;
            pastillasUI[1].transform.position = auxIbuprofeno;
            pastillasUI[2].transform.position = auxExtasis;

            pastillasUI[0].color = new Color(0.5f, 0.5f, 0.5f);
            pastillasUI[1].color = new Color(1, 1, 1);
            pastillasUI[2].color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if (pastilla == 2)
        {
            pastillasUI[0].transform.position = auxExtasis;
            pastillasUI[1].transform.position = auxHomeopatica;
            pastillasUI[2].transform.position = auxIbuprofeno;

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
