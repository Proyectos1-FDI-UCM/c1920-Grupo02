﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image currentPill;   //Borde dorado que muestra la pastilla que has seleccionado
    public Image[] pastillasUI;  //Interfaz del cambio de pastilla
    public Text time;            //Contador para el cambio de pastilla
    public GameObject arrows;
    public GameObject tutorialText;       //Texto para el tutorial inicial
    public Image[] diagramaTutorial;
    private Text tutorial;
    int tutorialHecho = 0;

    public GameObject returnMenu;   //Boton de reintentar
    string areaTutorial;

    public Image[] hearts; //Corazon lleno
    int maxLife;    //Vida máxima

    //Interfaz glóbulos
    public Text globulosRojosUI;
    public Text globulosBlancosUI;

    void Start()
    {
        areaTutorial = SceneManager.GetActiveScene().name;
        tutorial = tutorialText.GetComponentInChildren<Text>();
        //Desactivamos todo
        tutorialText.SetActive(false);
        pastillasUI[0].enabled = false;
        pastillasUI[1].enabled = false;
        pastillasUI[2].enabled = false;
        time.enabled = false;
        currentPill.enabled = false;
        arrows.SetActive(false);
        if (areaTutorial == "Area_Hito")
            Tutorial(0);

            maxLife = hearts.Length;    //Establecemos la çvida máxima
        GameManager.instance.SetUIManager(this);
    }
    public void Tutorial(int num)
    {
        if(areaTutorial == "Area_Hito")
        {
            if (num == 0)
            {
                diagramaTutorial[num].enabled = true;
                tutorialText.SetActive(true);
                tutorial.text = "Pulsa A - D o LeftArrow-RightArrow \n para moverte";
            }
            else if (num == 1 && tutorialHecho == 0)
            {
                diagramaTutorial[num].enabled = true;
                tutorial.text = "Pulsa W o UpArrow para saltar";
                tutorialHecho = 1;
            }
            else if (num == 2 && tutorialHecho == 1)
            {
                diagramaTutorial[num].enabled = true;
                tutorial.text = "Ahora eres una pastilla de ibuprofeno \n Pulsa Z o Shift para disparar con ella";
                tutorialHecho = 2;
            }
            else if (num == 3 && tutorialHecho == 2)
            {
                diagramaTutorial[num].enabled = true;
                tutorial.text = "Genial, Coge el PowerUp \n para conseguir mas pastillas";
            }
            else if (num == 4)
            {
                diagramaTutorial[num].enabled = true;
                tutorial.text = "Ahora puedes cambiar de pastillas \n pulsa tab para ver los controles";
                tutorialHecho = 3;
            }
            else if (num == 5 && tutorialHecho == 3)
                tutorialText.SetActive(false);
        }
        if (num == -1)
        {
            tutorialText.SetActive(true);
            tutorial.text = "HAS MUERTO";
        }
    }
    public void Dead()
    {
        returnMenu.SetActive(true);
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
        currentPill.enabled = true;
        arrows.SetActive(true);

        //0 = Homeopatica
        //1 = Ibuprofeno
        //2 = Extasis
        if (pastilla == 0)
        {
            currentPill.transform.position = pastillasUI[0].transform.position;
            pastillasUI[0].color = new Color(1, 1, 1);
            pastillasUI[1].color = new Color(0.5f, 0.5f, 0.5f);
            pastillasUI[2].color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if (pastilla == 1)
        {
            currentPill.transform.position = pastillasUI[1].transform.position;
            pastillasUI[0].color = new Color(0.5f, 0.5f, 0.5f);
            pastillasUI[1].color = new Color(1, 1, 1);
            pastillasUI[2].color = new Color(0.5f, 0.5f, 0.5f);
        }
        else if (pastilla == 2)
        {
            currentPill.transform.position = pastillasUI[2].transform.position;
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
