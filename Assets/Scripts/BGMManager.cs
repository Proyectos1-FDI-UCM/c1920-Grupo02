using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static AudioClip level1, level2;  //Nombre de los sonidos
    static AudioSource BGM;
    void Start()
    {
        level1 = Resources.Load<AudioClip>("level1");
        level2 = Resources.Load<AudioClip>("level2");
        BGM = GetComponent<AudioSource>();
    }
    void Update()
    {

    }
    public void changeBGM(AudioClip music)
    {
        if (BGM.clip.name != music.name)
        {
            BGM.Stop();
            BGM.clip = music;
            BGM.Play();
        }
    }
}
