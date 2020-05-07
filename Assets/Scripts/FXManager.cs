using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static AudioClip dashSound;  //Nombre de los sonidos
    static AudioSource audio;
    void Start()
    {
        dashSound = Resources.Load<AudioClip>("Music/dash");
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }
    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "dash":
                audio.PlayOneShot(dashSound);
                break;
        }
    }
}
