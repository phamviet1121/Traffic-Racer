using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest/QuestData")]
public class Constant_Data : ScriptableObject
{
    public QuestInfo_Constant[] QuestInfo_Constants;
}
[System.Serializable]
public class QuestInfo_Constant
{
    public int car_index;
    public float[] index_color;
    public int index_wheel;
    public int index_Sticker;
    public int index_speed;
    public int index_handling;
    public int index_barking;
    public bool status_car;

}