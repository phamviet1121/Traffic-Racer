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
            // Tính góc quay trong frame này (theo thời gian thực)
            float rotationAmount = rotationSpeed *10f * Time.deltaTime;

            // Duyệt qua tất cả các bánh xe và xoay chúng quanh trục mong muốn
            foreach (GameObject wheel in wheels)
            {
                // Xoay quanh trục X (tuỳ vào hướng trục bánh xe của bạn)
                wheel.transform.Rotate(Vector3.right * rotationAmount);
            }
        }

    }
}