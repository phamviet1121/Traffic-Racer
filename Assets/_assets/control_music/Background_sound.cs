using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_sound : MonoBehaviour
{

    public GameObject backgroundSound;
    private AudioSource source;
    private void Start()
    {
        source = backgroundSound.GetComponent<AudioSource>();
    }

    public void startBackgroundSound()
    {
        if (source != null)
        {
            Debug.Log("kêu chưa startBackgroundSound");
            source.loop = true;
            source.Play();
        }
    }
    public void StopBackgroundSound()
    {
        if (source != null)
        {
            Debug.Log("tắt chưa ");
            source.Stop();
        }

    }
}
