using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static AudioClip dashSound, puertaSound, oneShotSound, saltoSound, recibirDañoSound, changePillsound, coaguloEnergySound, disparoSound, clickSound, TaeniaBite;  //Nombre de los sonidos
    static AudioSource audio;
    void Start()
    {
        TaeniaBite = Resources.Load<AudioClip>("Music/SoundEffects/TaeniaBite");
        dashSound = Resources.Load<AudioClip>("Music/SoundEffects/dash");
        puertaSound = Resources.Load<AudioClip>("Music/SoundEffects/PuertaDesbloqueable");
        oneShotSound = Resources.Load<AudioClip>("Music/SoundEffects/OneShotGranCoagulo");
        saltoSound = Resources.Load<AudioClip>("Music/SoundEffects/Salto");
        recibirDañoSound = Resources.Load<AudioClip>("Music/SoundEffects/RecibirDaño");
        changePillsound = Resources.Load<AudioClip>("Music/SoundEffects/ChangePill");
        coaguloEnergySound = Resources.Load<AudioClip>("Music/SoundEffects/CoaguloEnergia");
        disparoSound = Resources.Load<AudioClip>("Music/SoundEffects/Disparo");
        clickSound = Resources.Load<AudioClip>("Music/SoundEffects/click");

        audio = GetComponent<AudioSource>();
    }
    public void ButtonSound(string sound)
    {
        PlaySound(sound);
    }
    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "dash":
                audio.PlayOneShot(dashSound);
                break;
            case "PuertaDesbloqueable":
                audio.PlayOneShot(puertaSound);
                break;
            case "OneShotGranCoagulo":
                audio.PlayOneShot(oneShotSound);
                break;
            case "Salto":
                audio.PlayOneShot(saltoSound);
                break;
            case "RecibirDaño":
                audio.PlayOneShot(recibirDañoSound);
                break;
            case "ChangePill":
                audio.PlayOneShot(changePillsound);
                break;
            case "CoaguloEnergia":
                audio.PlayOneShot(coaguloEnergySound);
                break;
            case "Disparo":
                audio.PlayOneShot(disparoSound);
                break;
            case "click":
                audio.PlayOneShot(clickSound);
                break;
            case "TaeniaBite":
                audio.PlayOneShot(TaeniaBite);
                break;
        }
    }
}
