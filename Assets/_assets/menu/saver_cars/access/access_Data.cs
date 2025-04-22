using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest/QuestData")]
public class access_Data : ScriptableObject
{
    public QuestInfo[] questInfos;
}
[System.Serializable]
public class QuestInfo
{
    public int car_index;
    public float[] index_color;
    public int index_wheel;
    public int index_Sticker;
    public int index_speed;
    public int index_handling;
    public int index_barking;
    public bool status_car;


    public void CopyFrom(QuestInfo_Constant constant)
    {
        this.car_index = constant.car_index;
        this.index_color = (float[])constant.index_color.Clone(); // Clone để tránh tham chiếu cùng mảng
        this.index_wheel = constant.index_wheel;
        this.index_Sticker = constant.index_Sticker;
        this.index_speed = constant.index_speed;
        this.index_handling = constant.index_handling;
        this.index_barking = constant.index_barking;
        this.status_car = constant.status_car;
    }

    
}
    