using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_rollingwheel : MonoBehaviour
{
    public GameObject[] wheels;
    public float rotationSpeed;
    void Update()
    {
        if (rotationSpeed > 0f && wheels != null)
        {
            float rotationAmount = rotationSpeed *10f * Time.deltaTime;

            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(Vector3.right * rotationAmount);
            }
        }

    }
}