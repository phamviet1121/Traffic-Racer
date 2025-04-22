using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class collider_canvas : MonoBehaviour
{
    public int index_speedup_speeddown;
    public int dieukhuyen_index;
    public GameObject input0;
    public GameObject input1;
    public GameObject input2;
    // Start is called before the first frame update
    private TiltControl tiltControl;
    private PanelInputHandler panelInputHandler;


    public GameObject[] txt1;
    public GameObject[] txt2;

    void Start()
    {
        input1.SetActive(true);
        input2.SetActive(true);
        tiltControl = input2.GetComponent<TiltControl>();
        panelInputHandler = input1.GetComponent<PanelInputHandler>();

        input1.SetActive(false);
        input2.SetActive(false);
        collider_input();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onclick_input1()
    {
        dieukhuyen_index++;
        if (dieukhuyen_index >= 3)
        {
            dieukhuyen_index = 0;
        }
        collider_input();
        for (int i = 0; i < txt1.Length; i++)
        {
            txt1[i].SetActive(i== dieukhuyen_index);
        }


    }
    public void onclick_input2()
    {
        index_speedup_speeddown = (index_speedup_speeddown + 1) % 2;

        collider_input();
        for (int i = 0; i < txt2.Length; i++)
        {
            txt2[i].SetActive(i == index_speedup_speeddown);
        }

    }
    public void collider_input()
    {
        if (index_speedup_speeddown == 0)
        {



            if (dieukhuyen_index == 0)
            {
                on_input0();
            }
            else if (dieukhuyen_index == 1)
            {
                on_input1();
            }
            else
            {
                on_input2();
            }
        }
        else
        {
            if (dieukhuyen_index == 0)
            {
                on_input0();
            }
            else if (dieukhuyen_index == 1)
            {
                on_input1();
            }
            else
            {
                on_input2();
            }
        }
    }
    public void on_input0()
    {


        input0.SetActive(true);
        input1.SetActive(false);
        input2.SetActive(false);

        if (panelInputHandler != null)
            panelInputHandler.on_setting_inputmoush = false;

        if (tiltControl != null)
            tiltControl.on_input_acceleration = false;

    }


    public void on_input1()
    {
        input0.SetActive(false);
        input1.SetActive(true);
        input2.SetActive(false);

        if (panelInputHandler != null)
            panelInputHandler.on_setting_inputmoush = true;

        if (tiltControl != null)
            tiltControl.on_input_acceleration = false;

    }
    public void on_input2()
    {
        input0.SetActive(false);
        input1.SetActive(false);
        input2.SetActive(true);

        if (panelInputHandler != null)
            panelInputHandler.on_setting_inputmoush = false;

        if (tiltControl != null)
            tiltControl.on_input_acceleration = true;

    }



}
