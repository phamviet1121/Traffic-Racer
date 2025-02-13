using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class turn_L_R : MonoBehaviour
{
    public UnityEvent<bool> Event_turn;
    public bool isColliding = false;  // Biến kiểm tra trạng thái va chạm


    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("carAI"))
    //    {
    //        Debug.Log("có chạy ko hả va chạm đi ");
    //        Event_turn.Invoke(true);
    //    }
    //    else
    //    {
    //        Event_turn.Invoke(false);
    //    }


    // }


    // Khi đối tượng bắt đầu va chạm
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("carAI"))
        {

            isColliding = true; // Đánh dấu là đang va chạm
            Event_turn.Invoke(true); // Gọi sự kiện khi bắt đầu va chạm
        }
    }

    // Khi đối tượng vẫn đang va chạm
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("carAI"))
        {
            isColliding = true; // Đảm bảo giữ trạng thái va chạm
            Event_turn.Invoke(true); // Gọi sự kiện nếu vẫn va chạm
        }
    }

    // Khi đối tượng không còn va chạm nữa
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("carAI"))
        {
            isColliding = false; // Đánh dấu không còn va chạm
            Event_turn.Invoke(false); // Gọi sự kiện khi không còn va chạm
        }
    }
}
