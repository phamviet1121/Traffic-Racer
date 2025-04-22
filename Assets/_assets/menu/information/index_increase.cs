using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class index_increase : MonoBehaviour
{
    public int A;
    public int index_speed_bar;
    public float max;
    public TextMeshProUGUI index_txt;
    public TextMeshProUGUI indexmoney_txt;
    public Image HealthBarSpriter;
    public GameObject btn_;
    int buy;
    public GameObject canvant_notMoney;

    public collider_icon collider_icon;

    public UnityEvent<int> event_save_;

    public void M()
    {
        if (collider_icon.money_data.money_iocn.icon_money >= buy)
        {
            if (index_speed_bar < max)
            {
                index_speed_bar += A;
                updatehealthbar(index_speed_bar, max);
                index_txt.text = index_speed_bar.ToString();
                event_save_.Invoke(index_speed_bar);

                collider_icon.money_data.money_iocn.icon_money -= buy;
                // Debug.Log("chay chua");
                if (index_speed_bar >= max)
                {
                    btn_.SetActive(false);
                }
                else
                {
                    btn_.SetActive(true);
                }

                text_increase();
            }
            else
            {
                //ko cho coong nua
                btn_.SetActive(false);
            }
        }
        else
        {
           
            canvant_notMoney.SetActive(true);
            collision_NotBuy collision_NotBuy = canvant_notMoney.GetComponent<collision_NotBuy>();
            collision_NotBuy.onStart(buy - collider_icon.money_data.money_iocn.icon_money);
        }


    }




    public void updatehealthbar(float _healthpointvalue, float maxhealthpoint)
    {
        HealthBarSpriter.fillAmount = _healthpointvalue / maxhealthpoint;
    }

    public void load_bar(int a)
    {
        index_speed_bar = a;
        HealthBarSpriter.fillAmount = a / max;
        index_txt.text = index_speed_bar.ToString();
        if (index_speed_bar >= max)
        {
            //tat luon
            btn_.SetActive(false);
        }
        text_increase();


    }
    public void text_increase()
    {
        if (1 >= (max - index_speed_bar) / A)
        {
            buy = 2000;
            indexmoney_txt.text = "2000";
        }
        else if (2 >= (max - index_speed_bar) / A)
        {
            buy = 1000;
            indexmoney_txt.text = "1000";
        }
        else
        {
            buy = 500;
            indexmoney_txt.text = "500";
        }
    }
}
