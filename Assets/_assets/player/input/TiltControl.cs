using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    public bool left = false;
    public bool right = false;

    public float tiltThreshold = 0.2f; // Ngưỡng để nhận biết nghiêng

    public bool on_input_acceleration=false;
    public mover mover;
    private void Start()
    {
       // on_input_acceleration = false;
    }
    void Update()
    {
        if(on_input_acceleration)
        {
            input_acceleration();
            mover.input_right = right;
            mover.input_left = left;
        }    
    }

    public void input_acceleration()
    {
        Vector3 acceleration = Input.acceleration;

        if (acceleration.x < -tiltThreshold)
        {
            left = true;
            right = false;
        }
        else if (acceleration.x > tiltThreshold)
        {
            left = false;
            right = true;
        }
        else
        {
            left = false;
            right = false;
        }
    }
}
