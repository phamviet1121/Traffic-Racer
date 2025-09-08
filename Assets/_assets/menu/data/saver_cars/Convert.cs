using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Convert : MonoBehaviour
{
    public access_Data access_Data;
    public Constant_Data Constant_Data;

    public int index_car;
    public void Awake()
    {
        onStart_load();
    }


    public void save_data_color(float x, float y, float z, float w)
    {
        access_Data.questInfos[index_car].index_color[0] = x;
        access_Data.questInfos[index_car].index_color[1] = y;
        access_Data.questInfos[index_car].index_color[2] = z;
        access_Data.questInfos[index_car].index_color[3] = w;
    }

    public void save_data_wheel(int index_wheel)
    {
        access_Data.questInfos[index_car].index_wheel = index_wheel;
        Debug.Log("may có chạy ko hả thằng cho");
    }

    public void save_data_Sticker(int index_sticker)
    {
        access_Data.questInfos[index_car].index_Sticker = index_sticker;
    }

    public void save_data_speed(int index_speed)
    {
        access_Data.questInfos[index_car].index_speed = index_speed;
    }
    public void save_data_handling(int index_handling)
    {
        access_Data.questInfos[index_car].index_handling = index_handling;
    }
    public void save_data_braking(int index_braking)
    {
        access_Data.questInfos[index_car].index_barking = index_braking;
    }
    public void save_data_speed(bool status)
    {
        access_Data.questInfos[index_car].status_car = status;
    }

    public void onStart_load()
    {



        // Khởi tạo mảng questInfos nếu nó chưa được khởi tạo
        if (access_Data.questInfos == null || access_Data.questInfos.Length != Constant_Data.QuestInfo_Constants.Length)
        {
            access_Data.questInfos = new QuestInfo[Constant_Data.QuestInfo_Constants.Length];
        }

        for (int i = 0; i < Constant_Data.QuestInfo_Constants.Length; i++)
        {
            if (access_Data.questInfos[i] == null )
            {
                access_Data.questInfos[i] = new QuestInfo();
                access_Data.questInfos[i].CopyFrom(Constant_Data.QuestInfo_Constants[i]);
            }


        }

    }



}
