using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCashDoubler : MonoBehaviour
{
    public Button CashDoublerOBJ;

    private void Start()
    {
        LoadIAPStates();
    }
    public void LoadIAPStates()
    {
        CashDoublerOBJ.interactable = PlayerPrefs.GetInt("CashDoublerActive", 0) == 0;
    }
  
}
