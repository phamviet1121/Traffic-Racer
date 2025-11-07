using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class canvas_gameOver_LV5 : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gamePlay;
    public TextMeshProUGUI txt_money;
    public TextMeshProUGUI txt_indexmoney;
    public point_moneys point_moneys;
    public money_data money_data;
    public save_data_json save_data_json;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void on_canvasgameover()
    {
        gameOver.SetActive(true);
        gamePlay.SetActive(false);
        txt_money.text= point_moneys.moneys.ToString();
        txt_indexmoney.text = (point_moneys.moneys / point_moneys.plus_moneys).ToString();
        money_data.money_iocn.icon_money += point_moneys.moneys;
        save_data_json.SaveToJson_dataToSave();
    }    
}
