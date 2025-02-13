using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRAycast_player : MonoBehaviour
{
    public float rayDistance = 10f;

    void Update()
    {
        //if (Input.GetKey(KeyCode.I))
        //{


     //   Vector3 poss=new Vector3(transform.position.x,1000f,transform.position.z);
            // Tạo một ray từ vị trí của camera (hoặc từ vị trí nào khác)
            Ray ray = new Ray(transform.position, transform.forward);
            
            // Kiểm tra va chạm với vật thể có tag "carAI"
            RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
        if (Physics.Raycast(ray, out hit, rayDistance))
            {
                Debug.Log("Đã chạm vào: " + hit.collider.gameObject.name);
                if (hit.collider.CompareTag("carAI"))
                {

                  //  Debug.Log("bị soi chúng ");
                    // Lấy script từ vật thể đã va chạm
                    MOVER_AI MOVER_AI = hit.collider.GetComponent<MOVER_AI>();

                    // Kiểm tra xem script có tồn tại và gọi hàm trong đó
                    if (MOVER_AI != null)
                    {
                        //Debug.Log("có re ko ha ");
                        MOVER_AI.turn_control(); // Gọi hàm trong script
                    }
                }
            }
        //}
    }
}
