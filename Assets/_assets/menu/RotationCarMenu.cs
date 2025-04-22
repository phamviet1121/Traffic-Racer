//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RotationCarMenu : MonoBehaviour
//{
//    public GameObject car;
//    private Vector2 startTouchPosition, endTouchPosition;
//    private float rotationSpeed = 0.2f;
//    private float minXRotation = 75f;
//    private float maxXRotation = 100f;

//    private Vector3 currentRotation;

//    void Start()
//    {
//        currentRotation = car.transform.eulerAngles;
//        currentRotation.y = 0f; // Đảm bảo trục Y luôn cố định
//    }

//    void Update()
//    {
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);

//            if (touch.phase == TouchPhase.Began)
//            {
//                startTouchPosition = touch.position;
//            }
//            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
//            {
//                endTouchPosition = touch.position;
//                Vector2 delta = endTouchPosition - startTouchPosition;

//                // Xoay cả trục X và Z cùng lúc
//                currentRotation.x = Mathf.Clamp(currentRotation.x + delta.y * rotationSpeed, minXRotation, maxXRotation);
//                currentRotation.z += delta.x * rotationSpeed;
//                currentRotation.y = 0f; // Đảm bảo trục Y luôn cố định

//                car.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z);

//                startTouchPosition = endTouchPosition;
//            }
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCarMenu : MonoBehaviour
{
    public GameObject car;
    private Vector2 startTouchPosition, endTouchPosition;
    public float rotationSpeed = 0.2f;
    public float minXRotation = 75f;
    public float maxXRotation = 100f;
    private float idleTime = 0f;
    private float autoRotateDelay = 2f;
    private float autoRotateSpeed = 10f;

    private Vector3 currentRotation;

    void Start()
    {
        //currentRotation = car.transform.eulerAngles;
        //currentRotation.y = 0f; // Đảm bảo trục Y luôn cố định
        start_carrotation();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            idleTime = 0f; // Reset thời gian chờ khi có tương tác

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                endTouchPosition = touch.position;
                Vector2 delta = endTouchPosition - startTouchPosition;

                // Xoay cả trục X và Z cùng lúc
                currentRotation.x = Mathf.Clamp(currentRotation.x + delta.y * rotationSpeed, minXRotation, maxXRotation);
                currentRotation.z += delta.x * rotationSpeed;
                currentRotation.y = 0f; // Đảm bảo trục Y luôn cố định

                car.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z);

                startTouchPosition = endTouchPosition;
            }
        }
        else
        {
            idleTime += Time.deltaTime;
            if (idleTime >= autoRotateDelay)
            {
                currentRotation.z += autoRotateSpeed * Time.deltaTime;
                car.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z);
            }
        }
    }


    public void start_carrotation()
    {
        currentRotation = car.transform.eulerAngles;
        currentRotation.y = 0f; // Đảm bảo trục Y luôn cố định
      //  Debug.Log("Initial Rotation: " + currentRotation);
    }
        


}

