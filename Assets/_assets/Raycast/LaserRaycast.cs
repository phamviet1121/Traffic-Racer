using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserRaycast : MonoBehaviour
{
   // public Transform startPoint; // Điểm xuất phát của tia laser (ví dụ: vật A)
    public LayerMask hitLayers; // Lớp của vật thể có thể bị ảnh hưởng
    public float rayDistance_infront = 10f;
    //public float rayDistance_left_right = 10f;

 //   public Vector3 displacement = new Vector3(2f, 0, 0); // Độ dịch chuyển khi bị chiếu trúng

    public UnityEvent UnityEvent_Blockage_Front;  // Tia phía trước
   // public UnityEvent UnityEvent_Blockage_Left;   // Tia bên trái
    //public UnityEvent UnityEvent_Blockage_Right;  // Tia bên phải

    void Update()
    {
        // Tia phía trước
        CastLaser(Vector3.forward, Color.red, rayDistance_infront, UnityEvent_Blockage_Front);

        // Tia bên trái
      //  CastLaser(Vector3.left, Color.red, rayDistance_left_right, UnityEvent_Blockage_Left);

        // Tia bên phải
      //  CastLaser(Vector3.right, Color.red, rayDistance_left_right, UnityEvent_Blockage_Right);
    }

    void CastLaser(Vector3 direction, Color debugColor, float rayDistance, UnityEvent blockageEvent)
    {
        RaycastHit hit;

        // Kiểm tra tia laser va chạm với đối tượng trong phạm vi xác định
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, rayDistance, Physics.DefaultRaycastLayers))
        {
            Transform hitObject = hit.transform;

            if (hitObject.CompareTag("carAI")) // Kiểm tra xem có phải đối tượng cần tác động không
            {
                // Kích hoạt sự kiện tương ứng với hướng tia laser
                blockageEvent.Invoke();
            }

            // Vẽ tia laser trong Scene để kiểm tra
           
        }
        Debug.DrawRay(transform.position, direction * rayDistance, debugColor);
    }

    //void DrawLaser()
    //{
    //    Debug.DrawRay(startPoint.position, startPoint.forward * rayDistance, Color.red);
    //}
}
