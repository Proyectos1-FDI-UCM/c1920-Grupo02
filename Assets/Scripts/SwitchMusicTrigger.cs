using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;
    private BGMManager theAM;
    void Start()
    {
        theAM = FindObjectOfType<BGMManager>();
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerControllerWallJump>())
        {
            if (newTrack != null)
                theAM.changeBGM(newTrack);
        }
    }
}
