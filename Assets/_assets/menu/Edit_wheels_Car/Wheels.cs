using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Wheels : MonoBehaviour
{

    public int index_wheel;
    public bool buy_wheel;
    public int money_wheel;
    public load_bool_Array Load_bool_Array;
    public GameObject lock_img_wheel;
    public Mesh meshFilter;
    public Material Material;

    public Choose_Wheels Choose_Wheels;

    public UnityEvent<int> UnityEvent_Wheel;

    public UnityEvent<Mesh, Material> event_Wheels;

    public UnityEvent<int> saver_wheel_index;

    public UnityEvent<GameObject, bool, int,int> event_blockwheel;

    private void Start()
    {
        buy_wheel = Load_bool_Array.load_classifyS_1(index_wheel);
        if (buy_wheel)
        {
            lock_img_wheel.SetActive(false);
        }
        else
        {
            lock_img_wheel.SetActive(true);
        }
    }
    public void Onclick_wheel_btn()
    {
        UnityEvent_Wheel.Invoke(index_wheel);
        update_wheel();
        if(buy_wheel==true)
        {
            save_wheel();
        }
        Onclick_blook_wheel();
    }
    public void save_wheel()
    {
        saver_wheel_index.Invoke(index_wheel);
    }
    public void update_wheel()
    {
        meshFilter = Choose_Wheels.MeshFilter_Data;
        Material = Choose_Wheels.Material_Wheel_Data;
        event_Wheels.Invoke(meshFilter, Material);
    }

    public void Onclick_Buy_Wheel()
    {
        buy_wheel = true;
        lock_img_wheel.SetActive(false);
        save_wheel();
        Load_bool_Array.Saver_classifyS_1(index_wheel, buy_wheel);
    }
    public void Onclick_blook_wheel()
    {
        event_blockwheel.Invoke(gameObject, buy_wheel, 1, money_wheel);
    }    
}
