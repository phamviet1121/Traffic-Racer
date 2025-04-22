using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Choose_Wheels : MonoBehaviour
{
    public Mesh[] filter_Wheels;


    public Material[] Materials_Wheels;

    public Mesh MeshFilter_Data;
    public Material Material_Wheel_Data;

    public int index_wheel;

    //public UnityEvent<MeshFilter, Material> event_Wheels;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void event_edit_wheels()
    {
        for (int i = 0; i < filter_Wheels.Length; i++)
        {
            if (i == index_wheel)
            {
                // event_Wheels.Invoke(filter_Wheels[i], Materials_Wheels[i]);
                MeshFilter_Data = filter_Wheels[i];
                Material_Wheel_Data = Materials_Wheels[i];
            }
        }
    }

    public void onclick_Wheel(int index)
    {
        index_wheel = index;
        event_edit_wheels();
    }
}
