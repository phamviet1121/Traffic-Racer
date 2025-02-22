using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class list_cars : MonoBehaviour
{
    public GameObject[] List_player_cars;
    public load_playerData load_playerData;
    public GameObject player;
    public int a;
    void Awake()
    {
        Debug.Log("list chạy");
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

            }
        }
    }    
}
