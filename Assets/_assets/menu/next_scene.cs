using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_scene : MonoBehaviour
{
    public menu_cars menu_cars;

    public int number;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextScene(string map)
    {

        number= menu_cars.index;
        PlayerData.Instance.SetPlayerData("a", number);
        PlayerData.Instance.LockData();
        SceneManager.LoadScene(map);

    }


}
