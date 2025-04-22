using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coler_car : MonoBehaviour
{
    public Material targetMaterial;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void update_color(float x_color, float y_color, float z_color, float w_color)
    {
        targetMaterial.color = new Color(x_color, y_color, z_color, w_color);
    }
        
}
