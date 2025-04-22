using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attribute_car_btn : MonoBehaviour
{
    public GameObject[] Attribute_btn;
    public GameObject[] ScRoll_View_Attribute;
    public int index;
    void Start()
    {
        onAttribute_btn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onAttribute_btn()
    {
        for (int i = 0; i < Attribute_btn.Length; i++)
        {
            if(i==index)
            {
                Attribute_btn[i].SetActive(true);
                ScRoll_View_Attribute[i].SetActive(true);
            }
            else
            {
                Attribute_btn[i].SetActive(false);
                ScRoll_View_Attribute[i].SetActive(false);
            }
        }
    }
    public void update_index_0()
    {
        index = 0;
        onAttribute_btn();
    }
    public void update_index_1()
    {
        index = 1;
        onAttribute_btn();
    }
    public void update_index_2()
    {
        index = 2;
        onAttribute_btn();
    }
    public void update_index_3()
    {
        index = 3;
        onAttribute_btn();
    }
}
