using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnSignal : MonoBehaviour
{
    public GameObject body_car;
    //public float turnspeed;
    //public float turntime;


    public void turnLeft()
    {
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, 0f, 5f);
    }

    public void turnRight()
    {
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, 0f, -5f);
    }
    public void Acceleration_car()
    {
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(-5f, 0f, currentRotation.z);
      
     
    }
    public void Deceleration_car()
    {


        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(5f, 0f, currentRotation.z);
    }
    public void Inactive()
    {
       body_car.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    public void Inactive_Turn()
    {
        // Khi không quay, đặt lại trục Z về 0, các trục khác không thay đổi
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x,0f, 0f);
    }
    public void Inactive_Deceleration_Acceleration_car_car()
    {
       
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation.z);
    }
}
