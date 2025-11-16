using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataRemoveAds : MonoBehaviour
{
    public Button RemoveAdsOBJ;
    void Start()
    {
        LoadIAPStates();
    }
    public void LoadIAPStates()
    {
        RemoveAdsOBJ.interactable = PlayerPrefs.GetInt("RemoveAdsActive", 0) == 0;
    }

}
