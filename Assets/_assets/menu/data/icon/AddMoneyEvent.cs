using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoneyEvent : MonoBehaviour
{
    public save_data_json savedatajson;
   public void addmoney(int point)
    {
        savedatajson.dataToSave.money_iocn.icon_money += point;
        savedatajson.SaveToJson_dataToSave();
    }    
}
