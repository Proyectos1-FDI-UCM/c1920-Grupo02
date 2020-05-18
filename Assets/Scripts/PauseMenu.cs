using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    PlayerInputActions inputActions;

    public AudioMixer audioMixer;

    public GameObject pauseUI;
    public GameObject optionsUI;
    public GameObject teclas;
    public GameObject chooseLevel;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Cancel.started += ctx => CallMenu();
        inputActions.PlayerControls.Controles.started += ctx => GameManager.instance.sumaTutorial(5);
    }

    void CallMenu()
    {
        //Si el juego está pausado...
        if (GameManager.instance.GetMenu() && (!optionsUI.activeSelf) && (!teclas.activeSelf)&&(chooseLevel==null||!chooseLevel.activeSelf))
        {
            //Vuelves a jugar
            Resume();
        }
        //Si no está pausado...
        else if (optionsUI.activeSelf)
        {
            BackOptions();
        }
        else if (teclas.activeSelf)
        {
            BackControls();
        }
        else if (chooseLevel !=null && chooseLevel.activeSelf)
        {
            BackChooseLevel();
        }
        else if (pauseUI != null)
            //Se pausa
            Pause();
    }

    /// <summary>
    /// Quita el menú y continua con el juego
    /// </summary>
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.UpdateMenu(false);
    }

    /// <summary>
    /// Pausa el juego y muestra el menú
    /// </summary>
    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        GameManager.instance.UpdateMenu(true);
    }
    /// <summary>
    /// Vuelve a la pantalla de inicio
    /// </summary>
    public void LoadMenu()
    {
        Time.timeScale = 1;
        GameManager.instance.ChangeScene("Menu");
    }

    /// <summary>
    /// Quita el nuevo
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(); //Esto no funciona desde el editor
    }

    /// <summary>
    /// Desactiva las opciones y muestra la configuración
    /// </summary>
    public void LoadOptions()
    {
        optionsUI.SetActive(true);
        if(pauseUI!=null)
            pauseUI.SetActive(false);
    }

    /// <summary>
    /// Método para configurar el volumen
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVol", volume);
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVol", volume);
    }
    /// <summary>
    /// Método para configurar la pantalla completa
    /// </summary>
    /// <param name="isFullScreen"></param>
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    /// <summary>
    /// Método para quitar la configuracion y volver al menú de pausa
    /// </summary>
    public void BackOptions()
    {
        optionsUI.SetActive(false);
        if(pauseUI!=null)
            pauseUI.SetActive(true);
    }
    public void BackChooseLevel()
    {
        chooseLevel.SetActive(false);
        if (pauseUI != null)
            pauseUI.SetActive(true);
    }
    public void LoadChooseLevel()
    {
        chooseLevel.SetActive(true);
        if (pauseUI != null)
            pauseUI.SetActive(false);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    /// <summary>
    /// Desactiva las opciones y muestra controles
    /// </summary>
    public void LoadControls()
    {
        teclas.SetActive(true);
        if (pauseUI != null)
            pauseUI.SetActive(false);
    }
    public void BackControls()
    {
        teclas.SetActive(false);
        if (pauseUI != null)
            pauseUI.SetActive(true);
    }
}
