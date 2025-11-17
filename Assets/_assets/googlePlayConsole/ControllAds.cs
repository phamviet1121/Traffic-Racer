using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;

public class ControllAds : MonoBehaviour
{
    private float newtime = 60f;
    private float time;
    private bool isAds;
    public UnityEvent eventAds;
    private void Start()
    {
        isAds = true;
        time=newtime;
    }
    private void Update()
    {
        if(PlayerPrefs.GetInt("RemoveAdsActive", 0) == 1)
        {
            return;
        }    
        time-=Time.deltaTime;
       if(time<=0&& isAds) 
       {
            isAds = false;
            eventAds.Invoke();
       }
    }
    public void ResetTime()
    {
        isAds = true;
        time = newtime;
    }
}
