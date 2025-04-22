using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class collision_buy : MonoBehaviour
{

    public menu_cars menu_cars;
    public GameObject A_true;
    public GameObject B_false;
    public TextMeshProUGUI _money;
    public money_data money_data;

    public int index;
    public bool index_bool;
    public GameObject truyenvao;
    int money_index;
    public GameObject canvant_notMoney;
    // Start is called before the first frame update
    //void Start()
    //{
    //    A_true.SetActive(true);
    //    B_false.SetActive(false);
    //}

    // Update is called once per frame


    public void dieukhuyen(GameObject M, bool t_f, int kieu, int money)
    {
        truyenvao = M;
        index_bool = t_f;
        index = kieu;
        money_index = money;
        _money.text = money.ToString();

        if (index_bool)
        {
            A_true.SetActive(true);
            B_false.SetActive(false);
        }
        else
        {
            A_true.SetActive(false);
            B_false.SetActive(true);
        }
    }

    public void buy()
    {
        if (money_index <= money_data.money_iocn.icon_money)
        {
            try
            {
                if (index == 0)
                {
                    color_car_btn color_car_btn = truyenvao.GetComponent<color_car_btn>();
                    if (color_car_btn != null)
                    {
                        color_car_btn.Onclick_Buy_Color();
                        money_data.money_iocn.icon_money -= money_index;
                    }
                }
                else if (index == 1)
                {
                    Wheels Wheels = truyenvao.GetComponent<Wheels>();
                    if (Wheels != null)
                    {
                        Wheels.Onclick_Buy_Wheel();
                        money_data.money_iocn.icon_money -= money_index;
                    }
                }
                else
                {
                    Sticker Sticker = truyenvao.GetComponent<Sticker>();
                    if (Sticker != null)
                    {
                        Sticker.Onclick_Buy_Sticker();
                        money_data.money_iocn.icon_money -= money_index;
                    }
                }
                chaylai();
            }
            catch (System.Exception e)
            {
                Debug.LogWarning($"Có lỗi xảy ra: {e.Message}");
            }
        }else
        {
            canvant_notMoney.SetActive(true );
            collision_NotBuy collision_NotBuy = canvant_notMoney.GetComponent<collision_NotBuy>();
            collision_NotBuy.onStart(money_index - money_data.money_iocn.icon_money);
        }



    }

    public void chaylai()
    {
        menu_cars.gameobject_car();

    }
    public void chaylaimenu()
    {
        A_true.SetActive(true);
        B_false.SetActive(false);
    }
}
