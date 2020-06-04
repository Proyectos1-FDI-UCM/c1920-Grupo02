using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Transform player;

    private UIManager theUIManager;         //LA HE HECHO PRIVADA- SAMUEL
    private const int MAXHP = 12;
    static private int life = MAXHP;
    public int getLife { get { return life; } private set { life = value; } } //Propiedad para obtener la vida de forma segura
    private Camera cam;  //Obtener la cámara

    static int globulosRojos = 0;
    static int globulosBlancos = 0;

    public static bool isQuitingGame = false;

    int pasado = 0;     //Variable para cambiar el color del fondo --Samuel y Javi

    bool playerCanAtMelee = true; // variable para registrar cuándo puede atacar a melee el jugador --- Javier
    bool menuPartidaSacado = false; // variable para saber si se ha desplegado el menú durante una partida --- Javier


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        //SavePlayer();

    }

    private void Start()
    {
        LoadPlayer();

        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "Menu" && currentScene.name != "Fin")
            player = GameObject.Find("Player").transform;
    }
    public void sumaTutorial(int num)
    {
        theUIManager.TutorialTrigger(num);
    }

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
        theUIManager.LifeCount(life);
        theUIManager.UpdateGlobulosBlancosUI(0);

        globulosBlancos = 0;
        theUIManager.UpdateGlobulosRojosUI(globulosRojos);
    }

    //Resetea el GM
    private void ResetGM()
    {
        //Asignamos parámetros
        globulosBlancos = 0;
        life = MAXHP;

        //Actualizamos el UIM
        if (theUIManager != null)
        {
            theUIManager.LifeCount(life);
            theUIManager.UpdateGlobulosRojosUI(globulosRojos);
            theUIManager.UpdateGlobulosBlancosUI(globulosBlancos);
        }
    }

    void ResetGM(GameManager gm)
    {
        gm.ResetGM();
    }

    //Crea una nueva partida en la escena designada
    public void NewGame(string sceneName)
    {
        LoadPlayer();
        ResetGM();
        //globulosPasoNivel = globulosRojos;
        ChangeScene(sceneName);

    }

    /// <summary>
    /// Comprueba si está vivo y aplica el daño a las vidas
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    public bool LoseLife(int damage)
    {
        bool vivo;
        FXManager.PlaySound("RecibeDaño");
        life -= damage;
        theUIManager.LifeCount(life);
        if (life > 0)
        {
            float time = 0;
            while (time < 1)
            {
                ColorCamara(time);
                time += 0.01f;
            }
            FXManager.PlaySound("deadSound");   //#audio
            vivo = true;
        }
        else
        {
            DieEffect.playerDying = false;
            player.gameObject.SetActive(false);
            theUIManager.TutorialTrigger(-1);
            Debug.Log("Has muerto");
            NewGame(SceneManager.GetActiveScene().name);
            vivo = false;
        }
        return vivo;
    }

    public void AddLife(int extra) //Para que los globulos rojos den vida al jugador 
    {

        if (life + extra > MAXHP) //Para que no se supere la vida maxima;
        {
            life = MAXHP;
        }
        else life += extra; //Se le suma la vida extra
        theUIManager.UpdateLife(life); //Actualizamos la UI convenientemente 
        Debug.Log(life);
    }
    /// <summary>
    /// Manda a la UI que actualice la imagen de las pastillas
    /// </summary>
    /// <param name="pastilla"></param>
    public void ActualPill(int pastilla)
    {
        theUIManager.PillChange(pastilla);
    }
    /// <summary>
    /// Manda a la UI que desactive las pastillas de la interfaz
    /// </summary>
    public void ColorPills()
    {
        theUIManager.ColorfulPill();
    }
    /// <summary>
    /// Manda a la UI el contador para que lo muestre en pantalla
    /// </summary>
    /// <param name="contador"></param>
    public void Contador(float contador)
    {
        theUIManager.Timing(contador);
    }
    /// <summary>
    /// Suma los globulos rojos que ha recogido y los muestra en pantalla
    /// </summary>
    /// <param name="globulos"></param>
    public void UpdateGlobulosRojos(int globulos)
    {
        globulosRojos += globulos;
        Debug.Log(globulosRojos + " globulos rojos");
        theUIManager.UpdateGlobulosRojosUI(globulosRojos);
    }
    /// <summary>
    /// Suma los globulos blancos que ha recogido y los muestra en pantalla
    /// </summary>
    /// <param name="globulos"></param>
    public void UpdateGlobulosBlancos(int globulos)
    {
        globulosBlancos += globulos;
        Debug.Log(globulosBlancos + " globulos blancos");
        theUIManager.UpdateGlobulosBlancosUI(globulosBlancos);
    }
    public int ReturnGlobulosBlancos() => globulosBlancos;

    public int ReturnGlobulosRojos() => globulosRojos;

    public int getMaxHP() { return MAXHP; }

    public float GetPlayerLooking() => player.lossyScale.x;
    // comprobación del estado de "playerLookingRight" --- Javier

    public void UpdateCanAtack(bool val) { playerCanAtMelee = val; } // actualización del estado de "playerCanAtMelee" --- Javier
    public bool GetPlayerCanAtack() => playerCanAtMelee; // comprobación del estado de "playerCanAtMelee" --- Javier

    public void CorreTiempo(bool val) { Time.timeScale = val ? 1f : 0f; } // congelamos o descongelamos el juego --- Javier

    public void UpdateMenu(bool val) { menuPartidaSacado = val; } // actualiza el campo privado "menuPartidaSacado" --- Javier
    public bool GetMenu() => menuPartidaSacado;  // comprueba el campo privado "menuPartidaSacado" --- Javier

    public void ChangeScene(string sceneName)
    {
        //Cambia la escena
        isQuitingGame = true;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        life = MAXHP;
    }
    public void NivelCompleted(string sceneName)
    {
        SavePlayer();
        //Cambia la escena
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        life = MAXHP;
    }

    /// <summary>
    /// Guarda la partida
    /// </summary>
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    //Nico No borreis esto, lo uso para depurar
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    { SavePlayer(); Debug.Log("Guardando"); }

    //    if (Input.GetKeyDown(KeyCode.L))
    //        LoadPlayer();
    //}

    /// <summary>
    /// Carga la partida
    /// </summary>
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadData();

        if (data != null)
        {
            life = data.health;
            globulosBlancos = 0;
            globulosRojos = data.globulosRojos;
            Debug.Log(data);
            //SceneManager.LoadScene(data.level, LoadSceneMode.Single);
        }
    }

    public void NewGame()
    {

        PlayerData data = SaveSystem.LoadData();
        if (data != null)
        {
            life = data.health;
            globulosBlancos = 0;
        }
    }
    public void ColorCamara(float time)
    {
        cam = Camera.main;
        if (life < 13 && life > 9)
        {
            cam.backgroundColor = new Color(47f / 255f, 75f / 255f, 118f / 255f);
        }
        else if (getLife < 10 && getLife > 6)
        {
            cam.backgroundColor = Color.Lerp(new Color(47f / 255f, 75f / 255f, 118f / 255f), new Color(54f / 255f, 0f, 85f / 255f), time);
        }
        else if (life < 7 && getLife > 3)
        {
            cam.backgroundColor = Color.Lerp(new Color(54f / 255f, 0f, 85f / 255f), new Color(90f / 255f, 0f, 50f / 255f), time);
        }
        else if (life < 4 && getLife >= 0)
        {
            cam.backgroundColor = Color.Lerp(new Color(90f / 255f, 0f, 50f / 255f), new Color(133f / 255f, 0f, 6f / 255f), time);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Establece el player en el GameManager
    /// </summary>
    /// <param name="newPlayer">Nuevo jugador</param>
    public void SetPlayer(GameObject newPlayer)
    {
        player = newPlayer.transform;
    }
}