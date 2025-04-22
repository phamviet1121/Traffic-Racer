using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collision_NotBuy : MonoBehaviour
{
    public TextMeshProUGUI notBuy_txt;
    public GameObject canvat_gift;

    public void onStart(long a)
    {
        notBuy_txt.text = $"YOU STILL <color=blue>{a}</color> MORE CASH TO GET THIS.";
    }

    public void onclick_YES()
    {
        gameObject.SetActive(false);
        canvat_gift.SetActive(true);
        
    }
    public void onclick_NO()
    {

        gameObject.SetActive(false);
    }

}
