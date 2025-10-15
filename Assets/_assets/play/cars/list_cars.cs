using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class list_cars : MonoBehaviour
{
    public GameObject[] List_player_cars;
    public load_playerData load_playerData;
    public GameObject player;
    public access_Data access_Data;
    public int a;
    public Choose_Wheels Choose_Wheels;
    public choose_Sticker choose_Sticker;
    void Awake()
    {
        //Debug.Log("list chạy");
        a = load_playerData.indexcar;
        start_loadscene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_loadscene()
    {
        if (List_player_cars == null || List_player_cars.Length == 0) return;
        if (load_playerData.indexcar < 0 || load_playerData.indexcar >= List_player_cars.Length) return;

        for (int i = 0; i < List_player_cars.Length; i++)
        {
            List_player_cars[i].SetActive(i == load_playerData.indexcar);
            if (i == load_playerData.indexcar)
            {

                player = List_player_cars[i];
                loadStart_play(player, i);
            }
        }
    }

    public void loadStart_play(GameObject player, int i)
    {
        float a, b, c, d;
        a = access_Data.questInfos[i].index_color[0];
        b = access_Data.questInfos[i].index_color[1];
        c = access_Data.questInfos[i].index_color[2];
        d = access_Data.questInfos[i].index_color[3];


        Mesh Mesh_wheel;
        Material Material_wheel;
        Mesh_wheel = Choose_Wheels.filter_Wheels[access_Data.questInfos[i].index_wheel];
        Material_wheel = Choose_Wheels.Materials_Wheels[access_Data.questInfos[i].index_wheel];


        Sprite Sprite_sticker;

        collider_menu_Car script_collider_car = player.GetComponent<collider_menu_Car>();
        if (script_collider_car != null)
        {
            script_collider_car.coler_car.update_color(a, b, c, d);
            script_collider_car.Edit_wheels.Edit_wheelsCar(Mesh_wheel, Material_wheel);


            if (access_Data.questInfos[i].index_Sticker < 0)
            {
                script_collider_car.Edit_Sticker.Off_Edit_Sticker_car();
            }
            else
            {
                Sprite_sticker = choose_Sticker.Sticker_Imgs[access_Data.questInfos[i].index_Sticker];
                script_collider_car.Edit_Sticker.Edit_Sticker_car(Sprite_sticker);
            }

        }

    }


    //bangs xe
    //sticker
    //  public void load_car_menu(int i)
    //{
    //    float a, b, c, d;
    //    a = Convert.access_Data.questInfos[index].index_color[0];
    //    b = Convert.access_Data.questInfos[index].index_color[1];
    //    c = Convert.access_Data.questInfos[index].index_color[2];
    //    d = Convert.access_Data.questInfos[index].index_color[3];

    //    Mesh Mesh_wheel;
    //    Material Material_wheel;
    //    Mesh_wheel = Choose_Wheels.filter_Wheels[Convert.access_Data.questInfos[index].index_wheel];
    //    Material_wheel = Choose_Wheels.Materials_Wheels[Convert.access_Data.questInfos[index].index_wheel];



    //    Sprite Sprite_sticker;

    //    collider_menu_Car script_collider_car = cars[i].GetComponent<collider_menu_Car>();
    //    if (script_collider_car != null)
    //    {
    //        script_collider_car.coler_car.update_color(a, b, c, d);
    //        script_collider_car.Edit_wheels.Edit_wheelsCar(Mesh_wheel, Material_wheel);


    //        if (Convert.access_Data.questInfos[index].index_Sticker < 0)
    //        {
    //            script_collider_car.Edit_Sticker.Off_Edit_Sticker_car();
    //        }
    //        else
    //        {
    //            Sprite_sticker = choose_Sticker.Sticker_Imgs[Convert.access_Data.questInfos[index].index_Sticker];
    //            script_collider_car.Edit_Sticker.Edit_Sticker_car(Sprite_sticker);
    //        }

    //    }

    //    int S, H, B;
    //    S = Convert.access_Data.questInfos[index].index_speed;
    //    H = Convert.access_Data.questInfos[index].index_handling;
    //    B = Convert.access_Data.questInfos[index].index_barking;
    //    increase increase = canvar_Cars_list[i].GetComponent<increase>();
    //    if (increase != null)
    //    {
    //      increase.index_increase_speed.load_bar(S);
    //        increase.index_increase_handling.load_bar(H);
    //        increase.index_increase_braking.load_bar(B);
    //        //Debug.Log("thay doio chua");
    //    }

    //    bool statusCar;
    //    statusCar = Convert.access_Data.questInfos[index].status_car;
    //    canvant_bool_car canvant_bool_car = canvar_Cars_list[i].GetComponent<canvant_bool_car>();
    //    if (canvant_bool_car != null)
    //    {
    //        canvant_bool_car.onStart_menucar(statusCar);
    //    }

    //}
}
