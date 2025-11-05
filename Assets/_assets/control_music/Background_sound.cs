using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_sound : MonoBehaviour
{

    public GameObject backgroundSound;
    private AudioSource source;
    private void Start()
    {
        source = backgroundSound.AddComponent<AudioSource>();
    }

    public void startBackgroundSound()
    {
        if (source != null)
        {
            source.loop = true;
            source.Play();
        }
    }
    public void StopBackgroundSound()
    {
        if (source != null && source.isPlaying)
        {
            source.Stop();
        }

    }
}
