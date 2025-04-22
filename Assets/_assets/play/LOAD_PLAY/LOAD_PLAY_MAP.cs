using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOAD_PLAY_MAP : MonoBehaviour
{
    public string[] MANE_scene;
    public next_scene next_scene;
    string nameScene;
    public int indexMode;

    public void play_map()
    {

        for (int i = 0; i < MANE_scene.Length; i++)
        {
            if (i == indexMode)
            {
                nameScene = MANE_scene[i];
            }
        }
        if (nameScene != null)
        {
            next_scene.nextScene(nameScene);
        }

    }

    public void clickMode(int click_indexMode)
    {
        indexMode = click_indexMode;
    }    

}
