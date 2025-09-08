using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest/QuestData")]
public class BoolArraySaver : ScriptableObject
{

    public lever2[] index_Cars;

}
[System.Serializable]
public class lever2
{
   public lever3[] Classifys;
}
[System.Serializable]
public class lever3
{
    public bool[] var_bool;
}