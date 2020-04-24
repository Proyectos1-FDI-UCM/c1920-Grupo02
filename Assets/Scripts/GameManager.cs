using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform player;

    private UIManager theUIManager;         //LA HE HECHO PRIVADA- SAMUEL
    private int life = 12;
    public int getLife { get { return life; } private set { life = value; } } //Propiedad para obtener la vida de forma segura
    private Camera cam;  //Obtener la cámara

    int globulosRojos = 0;
    int globulosBlancos = 0;

    int pasado = 0;     //Variable para cambiar el color del fondo --Samuel y Javi

    bool playerCanAtMelee = true; // variable para registrar cuándo puede atacar a melee el jugador --- Javier
    bool menuPartidaSacado = false; // variable para saber si se ha desplegado el menú durante una partida --- Javier
    float time = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    private void Update()
    {
        //Cambio de color del fondo según la vida que tengas
        if (time <1)
        {
            ColorCamara(time);
            time += Time.deltaTime;
        }
        else
            time = 0;
    }
    public void sumaTutorial(int num)
    {
        theUIManager.Tutorial(num);
    }

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
        theUIManager.LifeCount(life);
    }

    /// <summary>
    /// Comprueba si está vivo y aplica el daño a las vidas
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    public bool LoseLife(int damage)
    {
        bool vivo;
        life -= damage;
        theUIManager.LifeCount(life);
        if (life > 0)
        {
            vivo = true;
        }
        else
        {
            player.gameObject.SetActive(false);
            theUIManager.Tutorial(-1);
            Debug.Log("Has muerto");
            vivo = false;
        }
        return vivo;
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
    public int ReturnGlobulosBlancos() { return globulosBlancos; }

    public int ReturnGlobulosRojos() { return globulosRojos; }

    public float GetPlayerLooking() { return player.localScale.x; } // comprobación del estado de "playerLookingRight" --- Javier

    public void UpdateCanAtack(bool val) { playerCanAtMelee = val; } // actualización del estado de "playerCanAtMelee" --- Javier
    public bool GetPlayerCanAtack() { return playerCanAtMelee; } // comprobación del estado de "playerCanAtMelee" --- Javier

    void CorreTiempo(bool val) { Time.timeScale = val ? 1f : 0f; } // congelamos o descongelamos el juego --- Javier

    public void UpdateMenu(bool val) { menuPartidaSacado = val; } // actualiza el campo privado "menuPartidaSacado" --- Javier
    public bool GetMenu() { return menuPartidaSacado; } // comprueba el campo privado "menuPartidaSacado" --- Javier

    public void ChangeScene(string sceneName)
    {
        //Cambia la escena
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
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

        if (data.level != null)
        {
            life = data.health;
            globulosRojos = data.globulosRojos;
            globulosBlancos = data.globulsoBlancos;
            Debug.Log(data.level);
            SceneManager.LoadScene(data.level, LoadSceneMode.Single);
        }

    }
    public void ColorCamara(float time)
    {
        cam = Camera.main;
        if (life < 13 && life > 9 )
        {
            cam.backgroundColor = new Color(47f / 255f, 75f / 255f, 118f / 255f);
        }
        else if (getLife < 10 && getLife > 6 && pasado == 0)
        {
            cam.backgroundColor = Color.Lerp(new Color(47f / 255f, 75f / 255f, 118f / 255f), new Color(54f / 255f, 0f, 85f / 255f), time);
            if (Mathf.Round(time * 10) / 10 == 1)
                pasado++;
        }
        else if (life < 7 && getLife > 3 && pasado == 1)
        {
            cam.backgroundColor = Color.Lerp(new Color(54f / 255f, 0f, 85f / 255f), new Color(90f / 255f, 0f, 50f / 255f), time);
            if (Mathf.Round(time * 10) / 10 == 1)
                pasado++;
        }
        else if (life < 4 && getLife >= 0 && pasado == 2)
        {
            cam.backgroundColor = Color.Lerp(new Color(90f / 255f, 0f, 50f / 255f), new Color(133f / 255f, 0f, 6f / 255f), time);
            if (Mathf.Round(time * 10) / 10 == 1)
                pasado++;
        }
    }
}