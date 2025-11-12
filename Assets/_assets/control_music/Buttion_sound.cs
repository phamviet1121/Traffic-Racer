using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttion_sound : MonoBehaviour
{
    public GameObject buttionSound;
    private AudioSource source;
    public float valueSound;
    public Data_music data_music;
    private void Start()
    {
        source = buttionSound.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (data_music != null)
        {

            if (valueSound != data_music.DataMusicQuest.valueSound)
            {
                valueSound = data_music.DataMusicQuest.valueSound;
                SetValueSound();
            }
        }
    }

    public void Onclicksound()
    {
        if (source != null && data_music.DataMusicQuest.isSound==1)
        {
            source.Play();
        }
    }
    public  void SetValueSound()
    {
        source.volume = valueSound;
    }    
}
