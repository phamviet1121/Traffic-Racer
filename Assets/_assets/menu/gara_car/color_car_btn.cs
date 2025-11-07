using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class color_car_btn : MonoBehaviour
{
    public int index_color;
    public float x_color;
    public float y_color;
    public float z_color;
    public float w_color;
    public bool buy_color;
    public int money_color;
    public GameObject lock_img_color;
    public load_bool_Array Load_bool_Array;

    public UnityEvent<float, float, float, float> update_coler_Event;
    public UnityEvent<float, float, float, float> save_coler_Event;
    public UnityEvent<GameObject, bool, int,int> event_block_color;
    private void Start()
    {
        buy_color = Load_bool_Array.load_classifyS_0(index_color);
        if (buy_color)
        {
            lock_img_color.SetActive(false);
        }
        else
        {
            lock_img_color.SetActive(true);
        }
    }
    public void On_update_coler()
    {
        update_coler_Event.Invoke(x_color, y_color, z_color, w_color);
        if(buy_color==true)
        {
            //Debug.Log("may co doi mau ko ");
            svae_color();
        }
        Onclick_blook_color();
    }
    public void svae_color()
    {
        save_coler_Event.Invoke(x_color, y_color, z_color, w_color);
    }
    public void Onclick_Buy_Color()
    {
        buy_color = true;
        lock_img_color.SetActive(false);
        svae_color();
        Load_bool_Array.saver_classifyS_0(index_color, buy_color);

    }
    public void Onclick_blook_color()
    {
        event_block_color.Invoke(gameObject, buy_color, 0, money_color);
    }
}
