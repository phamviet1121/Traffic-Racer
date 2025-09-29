using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnSignal : MonoBehaviour
{
    public GameObject body_car;
    public LaserRAycast_player laserRAycast_player;
    private float turnningSpeed;
    //public float turnspeed;
    //public float turntime;

    private void Start()
    {
        turnningSpeed = 5f;
    }


    private void Update()
    {
        if (turningLeft)
        {
            turnLeft();
        }

        if (turningRight)
        {
            turnRight();
        }

        if (!turningLeft && !turningRight)
        {
            Inactive_Turn();
        }



    }

    float yAngle;
    float zAngle;
    float xAngle;


    const float LEFT_Y_ANGLE = -1;
    const float LEFT_Z_ANGLE = -10;
    const float X_ANGLE = -3;


    public bool turningLeft = false;
    public bool turningRight = false;
    public void StartTurnLeft()
    {
        turningLeft = true;
    }
    public void offTurnLeft()
    {
        turningLeft = false;
    }
    public void StartTurnRighgt()
    {
        turningRight = true;
    }
    public void offTurnRight()
    {
        turningRight = false;
    }

    private void turnLeft()
    {
        if (-yAngle >= -LEFT_Y_ANGLE)
            return;
        if (-zAngle >= -LEFT_Z_ANGLE)
            return;
        yAngle = Mathf.Max(turnningSpeed * Time.deltaTime * LEFT_Y_ANGLE + yAngle, LEFT_Y_ANGLE);
        zAngle = Mathf.Max(turnningSpeed * Time.deltaTime * LEFT_Z_ANGLE + zAngle, LEFT_Z_ANGLE);
       // xAngle = Mathf.Max(turnningSpeed * Time.deltaTime * X_ANGLE + xAngle, X_ANGLE);

        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(/*currentRotation.x*/xAngle, yAngle, zAngle);
        Debug.Log("left");

    }

    const float RIGHT_Y_ANGLE = 1;
    const float RIGHT_Z_ANGLE = 10;
    private void turnRight()
    {
        if (yAngle >= RIGHT_Y_ANGLE)
            return;
        if (zAngle >= RIGHT_Z_ANGLE)
            return;
        yAngle = Mathf.Min(turnningSpeed * Time.deltaTime * RIGHT_Y_ANGLE + yAngle, RIGHT_Y_ANGLE);
        zAngle = Mathf.Min(turnningSpeed * Time.deltaTime * RIGHT_Z_ANGLE + zAngle, RIGHT_Z_ANGLE);
        //xAngle = Mathf.Max(turnningSpeed * Time.deltaTime * X_ANGLE + xAngle, X_ANGLE);
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(/*currentRotation.x*/xAngle, yAngle, zAngle);
        Debug.Log("right");
    }
    public void Acceleration_car()
    {
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(-3f, 0f, currentRotation.z);


    }
    public void Deceleration_car()
    {
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(3f, 0f, currentRotation.z);
    }
    public void Inactive()
    {
        body_car.transform.rotation = Quaternion.Euler(0f, 0f, 0f);


    }

    public void Inactive_Turn()
    {

        if (xAngle == 0f && yAngle == 0f && zAngle == 0f)
            return;
        if (turningLeft || turningRight)
            return;
        
        // Giảm dần giá trị góc về 0 theo tốc độ nhất định
       // xAngle = Mathf.MoveTowards(xAngle, 0f, 3f * Time.deltaTime);
        yAngle = Mathf.MoveTowards(yAngle, 0f, 2f * Time.deltaTime*5f);
        zAngle = Mathf.MoveTowards(zAngle, 0f, 7f * Time.deltaTime*5f);

        // Cập nhật lại rotation cho body_car
        body_car.transform.rotation = Quaternion.Euler(xAngle, yAngle, zAngle);
        Debug.Log("dừng");
    }
    public void Inactive_Deceleration_Acceleration_car_car()
    {

        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z);
        //Debug.Log("Inactive_Deceleration_Acceleration_car_car: " + body_car.transform.rotation);
    }

    public void on_light()
    {
        laserRAycast_player.onlight = true;
    }
    public void off_light()
    {
        laserRAycast_player.onlight = false;
    }


}
