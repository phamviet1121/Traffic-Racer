using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class menu_cars : MonoBehaviour

{
    public GameObject[] cars;
    public GameObject[] canvar_Cars_list;
    public int index;


    public Convert Convert;
    public Choose_Wheels Choose_Wheels;
    public choose_Sticker choose_Sticker;

    public collision_buy collision_buy;

    public RotationCarMenu RotationCarMenu;

    public UnityEvent<int> indexcar;
    void Start()
    {
        index = PlayerData.Instance.playerLevel;
        Convert.index_car = index;
        gameobject_car();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void gameobject_car()
    {
        if (cars == null || cars.Length == 0) return; // Tránh lỗi nếu danh sách rỗng
        if (index < 0 || index >= cars.Length) return; // Đảm bảo index hợp lệ

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == index); // Chỉ bật xe tại vị trí index, tắt các xe khác
            canvar_Cars_list[i].SetActive(i == index);
            if (i == index)
            {
                indexcar.Invoke(index);
                RotationCarMenu.car = cars[i];
                RotationCarMenu.start_carrotation();
                if (i != 35)
                {
                    load_car_menu(i);
                }

                collision_buy.chaylaimenu();
            }
        }
        //Convert.access_Data.questInfos[index]
    }
    public void load_car_menu(int i)
    {
        float a, b, c, d;
        a = Convert.access_Data.questInfos[index].index_color[0];
        b = Convert.access_Data.questInfos[index].index_color[1];
        c = Convert.access_Data.questInfos[index].index_color[2];
        d = Convert.access_Data.questInfos[index].index_color[3];

        Mesh Mesh_wheel;
        Material Material_wheel;
        Mesh_wheel = Choose_Wheels.filter_Wheels[Convert.access_Data.questInfos[index].index_wheel];
        Material_wheel = Choose_Wheels.Materials_Wheels[Convert.access_Data.questInfos[index].index_wheel];



        Sprite Sprite_sticker;

        collider_menu_Car script_collider_car = cars[i].GetComponent<collider_menu_Car>();
        if (script_collider_car != null)
        {
            script_collider_car.coler_car.update_color(a, b, c, d);
            script_collider_car.Edit_wheels.Edit_wheelsCar(Mesh_wheel, Material_wheel);


            if (Convert.access_Data.questInfos[index].index_Sticker < 0)
            {
                script_collider_car.Edit_Sticker.Off_Edit_Sticker_car();
            }
            else
            {
                Sprite_sticker = choose_Sticker.Sticker_Imgs[Convert.access_Data.questInfos[index].index_Sticker];
                script_collider_car.Edit_Sticker.Edit_Sticker_car(Sprite_sticker);
            }

        }

        int S, H, B;
        S = Convert.access_Data.questInfos[index].index_speed;
        H = Convert.access_Data.questInfos[index].index_handling;
        B = Convert.access_Data.questInfos[index].index_barking;
        increase increase = canvar_Cars_list[i].GetComponent<increase>();
        if (increase != null)
        {
            increase.index_increase_speed.load_bar(S);
            increase.index_increase_handling.load_bar(H);
            increase.index_increase_braking.load_bar(B);
            //Debug.Log("thay doio chua");
        }

        bool statusCar;
        statusCar = Convert.access_Data.questInfos[index].status_car;
        canvant_bool_car canvant_bool_car = canvar_Cars_list[i].GetComponent<canvant_bool_car>();
        if (canvant_bool_car != null)
        {
            canvant_bool_car.onStart_menucar(statusCar);
        }

    }
    public void forward_btn()
    {
        if (index < cars.Length - 1)
        {
            index++;
            gameobject_car();
        }
        Convert.index_car = index;


    }
    public void back_btn()
    {
        if (index > 0)
        {
            index--;
            gameobject_car();
        }
        Convert.index_car = index;
    }
    public void buy_car()
    {
        Convert.access_Data.questInfos[index].status_car = true;

        int count = Convert.access_Data.questInfos.Count(q => q.status_car);
        int max = Convert.access_Data.questInfos.Length;
        if (count == max)
        {
            GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQDg");
        }
        if (count>=5)
        {
            GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQCw");
        }
        if (count >= 10)
        {
            GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQDA");
        }
           
        if (index == 1)
        {
            GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQDQ");
        }
    }

}
