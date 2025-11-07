using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttion_sound : MonoBehaviour
{
    public GameObject buttionSound;
    private AudioSource source;
    private void Start()
    {
        source = buttionSound.GetComponent<AudioSource>();
    }

    public void Onclicksound()
    {
        if (source != null)
        {
            source.Play();
        }
    }
}
