﻿using UnityEngine;
using UnityEngine.Audio;

public class RestartMenu : MonoBehaviour
{
    PlayerInputActions inputActions;
    bool cancel;

    public AudioMixer audioMixer;

    public GameObject PauseUI;
    public GameObject OptionsUI;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Cancel.started += ctx => cancel = true;
        inputActions.PlayerControls.Cancel.canceled += ctx => cancel = false;
        inputActions.PlayerControls.Cancel.performed += ctx => cancel = false;
    }
    void Update()
    {
        //Si pulsas Escape...
        if (cancel)
        {
            //Si el juego está pausado...
            if (GameManager.instance.GetMenu())
            {
                //Vuelves a jugar
                Resume();
            }
            //Si no está pausado...
            else
            {
                //Se pausa
                Pause();
            }
        }
    }

    /// <summary>
    /// Quita el menú y continua con el juego
    /// </summary>
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.UpdateMenu(false);
    }

    /// <summary>
    /// Pausa el juego y muestra el menú
    /// </summary>
    void Pause()
    {
        PauseUI.SetActive(true);
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
        OptionsUI.SetActive(true);
        PauseUI.SetActive(false);
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
        OptionsUI.SetActive(false);
        PauseUI.SetActive(true);
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}