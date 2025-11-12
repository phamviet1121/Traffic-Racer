using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Cars_sound : MonoBehaviour
{
    public GameObject engineSound;
    public GameObject whistleSound;
    public GameObject driftSound;
    public GameObject driftSound2;
    public GameObject crashSound;
    public GameObject bigcrashSound;
    public GameObject overtakeSound;
    public GameObject barrierHitSound;



    private AudioSource enginesource;
    private AudioSource whistlesource;
    private AudioSource driftsource;
    private AudioSource driftsource2;
    private AudioSource crashsource;
    private AudioSource bigcrashsource;
    private AudioSource overtakesource;
    private AudioSource barrierHitsource;

    private bool isAccelerated;
    private bool isDeceleration;
    private bool isDecelerationone;
    float pitchAngle = 1;

    public float valueSound;
    public Data_music data_music;
    private void Awake()
    {
        enginesource = engineSound.GetComponent<AudioSource>();
        whistlesource = whistleSound.GetComponent<AudioSource>();
        driftsource = driftSound.GetComponent<AudioSource>();
        driftsource2 = driftSound2.GetComponent<AudioSource>();
        crashsource = crashSound.GetComponent<AudioSource>();
        bigcrashsource = bigcrashSound.GetComponent<AudioSource>();
        overtakesource = overtakeSound.GetComponent<AudioSource>();
        barrierHitsource = barrierHitSound.GetComponent<AudioSource>();
        isAccelerated = false;
        isDeceleration = false;
        isDecelerationone = true;
        if (data_music != null)
        {
            
                startRunCarSound();
            
            if (valueSound != data_music.DataMusicQuest.valueSound)
            {
                valueSound = data_music.DataMusicQuest.valueSound;
                statusvalueSound();
            }
        }
    }
    private void Update()
    {
        if (isAccelerated && !isDeceleration)
        {
            Accelerated();
        }

        if (isDeceleration)
        {
            if (isDecelerationone == true)
            {
                Deceleration();
            }
            else
            {
                resetSound();
            }

        }
        else
        {
            isDecelerationone = true;
        }
        if (!isAccelerated && !isDeceleration)
        {
            resetSound();
        }
        if (data_music != null)
        {
            
            if (valueSound != data_music.DataMusicQuest.valueSound)
            {
                valueSound = data_music.DataMusicQuest.valueSound;
                statusvalueSound();
            }
        }
    }

    public void startRunCarSound()
    {
        if (enginesource != null && data_music.DataMusicQuest.isSound == 1)
        {
            enginesource.loop = true;
            enginesource.Play();
        }
    }

    public void stoptRunCarSound()
    {
        if (enginesource != null)
        {
            enginesource.Stop();
        }
    }
    public void startAcceleratedSound()
    {
        isAccelerated = true;
    }
    public void stopAcceleratedSound()
    {
        isAccelerated = false;
    }
    private void Accelerated()
    {
        if (pitchAngle >= 1.5)
            return;

        pitchAngle = Mathf.Min(pitchAngle + 0.5f * Time.deltaTime, 1.5f);
        if (enginesource != null)
        {
            enginesource.pitch = pitchAngle;
        }
    }

    private void resetSound()
    {
        if (pitchAngle == 1)
            return;
        pitchAngle = Mathf.MoveTowards(pitchAngle, 1f, 0.5f * Time.deltaTime);
        if (enginesource != null)
        {
            enginesource.pitch = pitchAngle;
        }

    }
    public void startDecelerationSound()
    {
        isDeceleration = true;
    }
    public void stopDecelerationSound()
    {
        isDeceleration = false;
    }
    private void Deceleration()
    {
        if (pitchAngle <= 0.5)
        {
            isDecelerationone = false;
            return;
        }


        pitchAngle = Mathf.Max(pitchAngle - 0.5f * Time.deltaTime, 0.5f);
        if (enginesource != null)
        {
            enginesource.pitch = pitchAngle;
        }
    }

    public void startWhistleSound()
    {
        if (whistlesource != null && data_music.DataMusicQuest.isSound == 1)
        {
            whistlesource.loop = true;
            whistlesource.Play();
        }
    }
    public void stopWhistleSound()
    {
        if (whistlesource != null)
        {
            whistlesource.Stop();
        }
    }
    public void onDriftSound()
    {
        if (driftsource != null && data_music.DataMusicQuest.isSound == 1)
        {
            driftsource.Play();
        }
    }
    public void onDriftSound2()
    {
        if (driftsource2 != null && data_music.DataMusicQuest.isSound == 1)
        {
            driftsource2.Play();
        }
    }
    public void onCrashSound()
    {
        if (crashsource != null && data_music.DataMusicQuest.isSound == 1)
        {
            crashsource.Play();
        }
    }
    public void onbigcrashSound()
    {
        if (bigcrashsource != null && data_music.DataMusicQuest.isSound == 1)
        {
            bigcrashsource.Play();
        }
    }
    public void onovertakeSound()
    {
        if (overtakesource != null && data_music.DataMusicQuest.isSound == 1)
        {
            overtakesource.Play();
        }
    }
    public void onbarrierHitSound()
    {
        if (barrierHitsource != null && data_music.DataMusicQuest.isSound == 1)
        {
            barrierHitsource.Play();
        }
    }

    public void statusvalueSound()
    {
        enginesource.volume = valueSound;
        whistlesource.volume = valueSound;
        driftsource.volume = valueSound;
        driftsource2.volume = valueSound;
        crashsource.volume = valueSound;
        bigcrashsource.volume = valueSound;
        overtakesource.volume = valueSound;
        barrierHitsource.volume = valueSound;
    }



}
