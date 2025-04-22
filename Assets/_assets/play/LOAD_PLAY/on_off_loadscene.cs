using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class on_off_loadscene : MonoBehaviour
{
   public string sceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void on_loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void on_player()
    {
        Time.timeScale = 1;
    }

    public void on_unlock()
    {
        PlayerData.Instance.unLockData();
    }    

    //public void on_menu_load()
    //{
    //    PlayerData.unLockData();
    //}    
}
