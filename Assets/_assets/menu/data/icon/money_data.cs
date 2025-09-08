
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMoneyQuest", menuName = "Quest/NewMoneyQuest")]
public class money_data : ScriptableObject
{
    public icon money_iocn;

}

[System.Serializable]
public class icon
{
    public long icon_money;
}
