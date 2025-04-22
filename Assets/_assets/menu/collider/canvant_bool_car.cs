using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class canvant_bool_car : MonoBehaviour
{
    public GameObject canvant_menu;
    public GameObject canvant_block;
    public TextMeshProUGUI money_txt;
    public int buy_money;
    public money_data money_data;
    public menu_cars menu_Cars;
    public GameObject canvant_notMoney;
    public Button play_btn;
    
    void Start()
    {
        money_txt.text= buy_money.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onStart_menucar(bool s)
    {
        if (s == true)
        {
            canvant_menu.SetActive(true);
            canvant_block.SetActive(false);
            play_btn.interactable = true;
        }
        else
        {
            canvant_menu.SetActive(false);
            canvant_block.SetActive(true);
            play_btn.interactable = false;
        }

        //canvant_menu.SetActive(s);
        //canvant_block.SetActive(!s);
    }


    public void onclick_buyCar()
    {
        if (money_data.money_iocn.icon_money >= buy_money)
        {
            menu_Cars.buy_car();

            canvant_menu.SetActive(true);
            canvant_block.SetActive(false);
            play_btn.interactable = true;
            money_data.money_iocn.icon_money -= buy_money;
        }
        else
        {
            canvant_notMoney.SetActive(true);
            collision_NotBuy collision_NotBuy = canvant_notMoney.GetComponent<collision_NotBuy>();
            collision_NotBuy.onStart(buy_money - money_data.money_iocn.icon_money);
        }

    }
}
