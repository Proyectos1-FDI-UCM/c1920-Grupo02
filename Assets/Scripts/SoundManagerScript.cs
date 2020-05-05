using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip dashSound;  //Nombre de los sonidos
    static AudioSource audio;
    void Start()
    {
        dashSound = Resources.Load<AudioClip>("dashSound");
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {

    }
    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "dashSound":
                audio.PlayOneShot(dashSound);
                break;
        }
    }
}
