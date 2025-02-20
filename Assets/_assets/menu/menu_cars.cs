using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_cars : MonoBehaviour

{
    public GameObject[] cars;

    public int index;

    public RotationCarMenu RotationCarMenu;
    void Start()
    {
        gameobject_car();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void gameobject_car()
    {
        if (cars == null || cars.Length == 0) return; // Tránh lỗi nếu danh sách rỗng
        if (index < 0 || index >= cars.Length) return; // Đảm bảo index hợp lệ

        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(i == index); // Chỉ bật xe tại vị trí index, tắt các xe khác
            if(i == index)
            {

                RotationCarMenu.car = cars[i];
            }
        }
    }

    public void forward_btn()
    {
        if (index < cars.Length-1)
        {
            index++;
            gameobject_car();
        }


    }
    public void back_btn()
    {
        if (index > 0)
        {
            index--;
            gameobject_car();
        }

    }


}
