using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollingwheel : MonoBehaviour
{

    public GameObject[] wheels;
    public float rotationSpeed;
    float resetSpeed;
    public float acceleratespeed;
    void Update()
    {
        if (rotationSpeed > 0f && wheels != null)
        {
            // Tính góc quay trong frame này (theo th?i gian th?c)
            float rotationAmount = rotationSpeed * 10f * Time.deltaTime;

            // Duy?t qua t?t c? các bánh xe và xoay chúng quanh tr?c mong mu?n
            foreach (GameObject wheel in wheels)
            {
                // Xoay quanh tr?c X (tu? vào h??ng tr?c bánh xe c?a b?n)
                wheel.transform.Rotate(Vector3.right * rotationAmount);
            }
        }

    }
    public void acceleratewheelSpeed()
    {
        resetSpeed = rotationSpeed;
        rotationSpeed += acceleratespeed;

    }
    public void resetwheelSpeed()
    {
        rotationSpeed = resetSpeed;
    }    

}
