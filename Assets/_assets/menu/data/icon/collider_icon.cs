using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collider_icon : MonoBehaviour
{
    public money_data money_data;
    public TextMeshProUGUI icon_txt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        icon_txt.text= money_data.money_iocn.icon_money.ToString();
    }
}
