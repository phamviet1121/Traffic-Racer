using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }

    public string playerName;
    public int playerLevel;
    //public float health;

    private bool isLocked = false; // Khóa dữ liệu khi sang Scene 2

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại khi chuyển Scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerData(string name, int level/*, float hp*/)
    {
        if (!isLocked) // Chỉ cho phép chỉnh sửa ở Scene 1
        {
            playerName = name;
            playerLevel = level;
           // health = hp;
        }
    }

    public void LockData() // Gọi khi sang Scene 2
    {
        isLocked = true;
    }
    public void unLockData() // Gọi khi sang Scene 1
    {
        isLocked = false;
    }

}
