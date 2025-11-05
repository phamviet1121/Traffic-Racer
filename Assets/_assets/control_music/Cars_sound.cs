using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Cars_sound : MonoBehaviour
{
    public GameObject engineSound;
    public GameObject whistleSound;
    public GameObject driftSound;
    public GameObject crashSound;
    public GameObject bigcrashSound;



    private AudioSource enginesource;
    private AudioSource whistlesource;
    private AudioSource driftsource;
    private AudioSource crashsource;
    private AudioSource bigcrashsource;


    private bool isAccelerated;
    private bool isDeceleration;
    private bool isDecelerationone;
    float pitchAngle = 1;

    private void Start()
    {
        enginesource = engineSound.GetComponent<AudioSource>();
        whistlesource = whistleSound.GetComponent<AudioSource>();
        driftsource = driftSound.GetComponent<AudioSource>();
        crashsource = crashSound.GetComponent<AudioSource>();
        bigcrashsource = bigcrashSound.GetComponent<AudioSource>();
        isAccelerated = false;
        isDeceleration = false;
        isDecelerationone = true;
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
    }

    public void startRunCarSound()
    {
        if (enginesource != null)
        {
            enginesource.loop = true;
            enginesource.Play();
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
        if (whistlesource != null)
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
        if (driftsource != null)
        {
            driftsource.Play();
        }
    }
    public void onCrashSound()
    {
        if (crashsource != null)
        {
            crashsource.Play();
        }
    }
    public void onbigcrashSound()
    {
        if (bigcrashsource != null)
        {
            bigcrashsource.Play();
        }
    }



}
