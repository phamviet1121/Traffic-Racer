using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewMusicQuest", menuName = "Quest/MusicQuest")]
public class Data_music : ScriptableObject
{
    public music DataMusicQuest;
}


[System.Serializable]
public class music
{
    public int isMusic;
    public float valueMusic;
    public int isSound;
    public float valueSound;

}
