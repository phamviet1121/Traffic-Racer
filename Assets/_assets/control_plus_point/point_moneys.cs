using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class point_moneys : MonoBehaviour
{
    public TextMeshProUGUI point_money_txt;

    public int plus_moneys;
    public int moneys;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void point_point_moneys()
    {
        moneys += plus_moneys;
        point_money_txt.text = moneys.ToString() +" đ ";
    }    

}
