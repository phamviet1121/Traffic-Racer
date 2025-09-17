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
        turnningSpeed = 3f;
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


    const float LEFT_Y_ANGLE = -2;
    const float LEFT_Z_ANGLE = -7;


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

        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, yAngle, zAngle);

    }

    const float RIGHT_Y_ANGLE = 2;
    const float RIGHT_Z_ANGLE = 7;
    private void turnRight()
    {
        if (yAngle >= RIGHT_Y_ANGLE)
            return;
        if (zAngle >= RIGHT_Z_ANGLE)
            return;
        yAngle = Mathf.Min(turnningSpeed * Time.deltaTime * RIGHT_Y_ANGLE + yAngle, RIGHT_Y_ANGLE);
        zAngle = Mathf.Min(turnningSpeed * Time.deltaTime * RIGHT_Z_ANGLE + zAngle, RIGHT_Z_ANGLE);

        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, yAngle, zAngle);

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

        if (yAngle == 0f && zAngle == 0f)
            return;

        if (yAngle < 0)
        {
            yAngle = Mathf.Max(turnningSpeed * Time.deltaTime * 2f + yAngle, 0);
        }
        else
        {
            yAngle = Mathf.Min(turnningSpeed * Time.deltaTime * -2f + yAngle, 0);
        }
        if (zAngle < 0)
        {
            zAngle = Mathf.Max(turnningSpeed * Time.deltaTime * 7f + zAngle, 0);

        }
        else
        {
            zAngle = Mathf.Min(turnningSpeed * Time.deltaTime * -7f + zAngle, 0);
        }

        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, yAngle, zAngle);
    }
    public void Inactive_Deceleration_Acceleration_car_car()
    {

        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation.z);
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
