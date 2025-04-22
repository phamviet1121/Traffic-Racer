using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choose_Sticker : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Sticker_Imgs;
    public Sprite Sticker_Image;
    public int index_img;

    public void event_edit_Sticker()
    {
        for (int i = 0; i < Sticker_Imgs.Length; i++)
        {
            if (i == index_img)
            {
                Sticker_Image = Sticker_Imgs[i];


            }
        }
    }


    public void onclick_Sticker_Imgs(int index)
    {
        index_img = index;
        event_edit_Sticker();
    }

}

