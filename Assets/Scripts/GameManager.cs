using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform player;
    private UIManager theUIManager;         //LA HE HECHO PRIVADA- SAMUEL
    private int life = 12;
    int globulosRojos = 0;
    int globulosBlancos = 0;
    bool playerLookingRight = true; // variable para registrar hacia dónde mira el jugador --- Javier
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
            Destroy(this.gameObject);
    }

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
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
    public void DesactivatePill()
    {
        theUIManager.UnablePill();
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
}