using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserRAycast_player : MonoBehaviour
{
    public float rayDistance = 10f;
    public GameObject[] lights;
    public bool onlight;


    void Update()
    {

        if (onlight)
        {

            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
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
        }
        else
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
        }


    }
}
