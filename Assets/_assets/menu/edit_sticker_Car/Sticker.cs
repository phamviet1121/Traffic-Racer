using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Sticker : MonoBehaviour
{
    public int index_StickerImg;
    public bool buy_sticker;
    public int money_Sticker;
    public GameObject lock_img_sticker;

    public load_bool_Array Load_bool_Array;

    public Sprite targetImage_car;

    public choose_Sticker choose_Sticker;

    public UnityEvent<int> UnityEvent_Sticker;

    public UnityEvent<Sprite> event_Sticker;
    public UnityEvent event_null_Sticker_Image;
    public UnityEvent<int> saver_Sticker_index;
    public UnityEvent<GameObject, bool, int, int> event_block_sticker;
    private void Start()
    {
        buy_sticker = Load_bool_Array.load_classifyS_2(index_StickerImg+1);
        if (buy_sticker)
        {
            lock_img_sticker.SetActive(false);
        }
        else
        {
            lock_img_sticker.SetActive(true);
        }
    }
    public void Onclick_Sticker_btn()
    {
        if (index_StickerImg >= 0)
        {
            UnityEvent_Sticker.Invoke(index_StickerImg);
            update_Sticker();


        }
        else
        {
            event_null_Sticker_Image.Invoke();

        }

        if (buy_sticker == true)
        {
            save_sticker();
        }
        Onclick_blook_wheel();
    }
    public void save_sticker()
    {
        saver_Sticker_index.Invoke(index_StickerImg);
    }

    public void update_Sticker()
    {
        targetImage_car = choose_Sticker.Sticker_Image;
        event_Sticker.Invoke(targetImage_car);
    }

    public void Onclick_Buy_Sticker()
    {
        buy_sticker = true;
        lock_img_sticker.SetActive(false);
        save_sticker();
        Load_bool_Array.Saver_classifyS_2(index_StickerImg+1, buy_sticker);
    }

    public void Onclick_blook_wheel()
    {
        event_block_sticker.Invoke(gameObject, buy_sticker, 2, money_Sticker);
    }
}
