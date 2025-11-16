using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnSignal : MonoBehaviour
{
    public GameObject body_car;
    public LaserRAycast_player laserRAycast_player;
    private float turnningSpeed;
    private float turnningSpeed_x;
    //public float turnspeed;
    //public float turntime;

    private void Start()
    {
        turnningSpeed = 5f;
        turnningSpeed_x = 10f;
    }


    private void Update()
    {
        if (turningLeft)
        {
            turnLeft();
            Xturnning_car();
        }

        if (turningRight)
        {
            turnRight();
            Xturnning_car();
        }

        if (!turningLeft && !turningRight)
        {
            Inactive_Turn();
            if (!isAcceleration && !isDeceleration)
            {
                Inactive_Turn_x();
            }
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

        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, yAngle, zAngle);
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
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, yAngle, zAngle);
    }
    const float X_Acceleration = -3;
    bool isAcceleration = false;
    public void Acceleration_car()
    {
        isAcceleration = true;
        if (-xAngle >= -X_Acceleration)
            return;
        xAngle = Mathf.Max(turnningSpeed * Time.deltaTime * X_Acceleration + xAngle, X_Acceleration);
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(xAngle, currentRotation.y, currentRotation.z);


    }
    const float X_Deceleration = 3;
    bool isDeceleration = false;
    public void Deceleration_car()
    {
        isDeceleration = true;
        if (xAngle >= X_Deceleration)
            return;
        xAngle = Mathf.Min(turnningSpeed * Time.deltaTime * X_Deceleration + xAngle, X_Deceleration);
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(xAngle, currentRotation.y, currentRotation.z);
    }

    const float X_turnning = -3;
    public void Xturnning_car()
    {
        if (xAngle <= X_turnning)
            return;
        xAngle = Mathf.Max(turnningSpeed * Time.deltaTime * X_turnning + xAngle, X_turnning);
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(xAngle, currentRotation.y, currentRotation.z);
    }

    public void Inactive_Turn_x()
    {
        if (xAngle == 0f)
            return;
        if (turningLeft || turningRight)
            return;
        xAngle = Mathf.MoveTowards(xAngle, 0f, 3f * Time.deltaTime);
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(xAngle, currentRotation.y, currentRotation.z);
    }
    public void Inactive()
    {
        body_car.transform.rotation = Quaternion.Euler(0f, 0f, 0f);


    }

    public void Inactive_Turn()
    {

        if (/*xAngle == 0f &&*/ yAngle == 0f && zAngle == 0f)
            return;
        if (turningLeft || turningRight)
            return;

        yAngle = Mathf.MoveTowards(yAngle, 0f, 2f * Time.deltaTime * 5f);
        zAngle = Mathf.MoveTowards(zAngle, 0f, 7f * Time.deltaTime * 5f);

        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(currentRotation.x, yAngle, zAngle);
    }
    public void Inactive_Deceleration_Acceleration_car_car()
    {
        
        isDeceleration = isAcceleration = false;
        if (xAngle == 0)
            return;
        if (turningLeft || turningRight)
            return;

        xAngle = Mathf.MoveTowards(xAngle, 0f, 3f * Time.deltaTime * 5f);
        Vector3 currentRotation = body_car.transform.rotation.eulerAngles;
        body_car.transform.rotation = Quaternion.Euler(xAngle, currentRotation.y, currentRotation.z);
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
