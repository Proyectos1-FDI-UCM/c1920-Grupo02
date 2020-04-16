using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public GameObject pauseUI;
    public GameObject optionsUI;
    public GameObject controles;
    void Update()
    {
        //Si pulsas Escape...
        if (Input.GetButtonDown("Cancel"))
        {
            //Si el juego está pausado...
            if (GameManager.instance.GetMenu() && (!optionsUI.activeSelf))
            {
                //Vuelves a jugar
                Resume();
            }
            //Si no está pausado...
            else if (optionsUI.activeSelf)
            {
                BackOptions();
            }
            else
                //Se pausa
                Pause();
        }
        //Si presionas tabulador....
        if (Input.GetButtonDown("Controles"))   //NO SE COMO HACER QUE SOLO APAREZCA CUANDO ESTÁ SIENDO PRESIONADO CON EL BUTTON
        {
            controles.SetActive(true);
        }
        if (Input.GetButtonUp("Controles"))
        {
            controles.SetActive(false);
        }
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
        pauseUI.SetActive(false);
    }

    /// <summary>
    /// Método para configurar el volumen
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
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
        pauseUI.SetActive(true);
    }
}
