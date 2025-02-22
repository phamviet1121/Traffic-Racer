using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_playerData : MonoBehaviour
{

    public int indexcar;

    void Awake()
    {
        Debug.Log("player_car:"+PlayerData.Instance.playerLevel+" name"+ PlayerData.Instance.playerName);

        indexcar = PlayerData.Instance.playerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
