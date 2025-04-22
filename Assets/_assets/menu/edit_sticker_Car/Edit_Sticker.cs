using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edit_Sticker : MonoBehaviour
{
    public GameObject[] Sticker;
    
    public void Edit_Sticker_car(Sprite targetImage)
    {
        for (int i = 0; i < Sticker.Length; i++)
        {
            Sticker[i].SetActive(true);
            Image stickerImage = Sticker[i].GetComponent<Image>(); // Lấy component Image từ GameObject
            if (stickerImage != null)
            {
                stickerImage.sprite = targetImage; // Gán sprite mới
            }
        }
    }

    public void Off_Edit_Sticker_car()
    {
        for (int i = 0; i < Sticker.Length; i++)
        {
            Debug.Log(" có chạy ko tắt đi chứ ");
            Sticker[i].SetActive(false);
            
        }
    }
}
