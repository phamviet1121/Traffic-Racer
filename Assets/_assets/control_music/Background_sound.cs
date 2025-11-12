using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Background_sound : MonoBehaviour
{

    public GameObject backgroundSound;
    private AudioSource source;
    public float valueMusic;
    public float StartvalueMusic;
    public Data_music data_music;

    private void Start()
    {
        source = backgroundSound.GetComponent<AudioSource>();
        if (data_music != null)
        {
            
                startBackgroundSound();
            
            if (valueMusic != data_music.DataMusicQuest.valueMusic)
            {
                valueMusic = data_music.DataMusicQuest.valueMusic;
                SetValueMusic();
            }
        }
    }
    private void Update()
    {
        if (data_music != null)
        {
          
            if (valueMusic != data_music.DataMusicQuest.valueMusic)
            {
                valueMusic = data_music.DataMusicQuest.valueMusic;
                SetValueMusic();
            }
        }
    }

    public void startBackgroundSound()
    { 
        if (source != null && data_music.DataMusicQuest.isMusic == 1)
        {
            source.loop = true;
            source.Play();
        }
        if(data_music.DataMusicQuest.isMusic == 0)
        {
            StopBackgroundSound();
        }    
    }
    public void StopBackgroundSound()
    {
        if (source != null)
        {
            source.Stop();
        }

    }
    
    public void SetValueMusic()
    {
        source.volume = StartvalueMusic* valueMusic;
    }
}
