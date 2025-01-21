using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVER_AI : MonoBehaviour
{
    public float speedrandommax;
    public float speedrandommin;
    public float minX;
    public float maxX;
    float speed;
    int turnint;
    public bool isCollided = false;
    void Start()
    {
        speed = Random.Range(speedrandommin, speedrandommax);
        turnint = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollided)
        {

            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            if (turnint == 1 && transform.position.x >= minX)
            {
                //Debug.Log("rẽ trái");
                turnint = 0;
            }
            else if (turnint == 2 && transform.position.x <= maxX)
            {
                //Debug.Log("rẽ phải");
                turnint = 0;
            }
        }
        else
        {

            speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 2f); // Tăng tốc độ giảm dần
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);

            // Kiểm tra nếu tốc độ gần bằng 0 thì dừng di chuyển
            if (speed <= 0.01f)
            {
                speed = 0f;
                enabled = false; // Vô hiệu hóa Update để dừng đối tượng
                //Debug.Log("Đối tượng đã dừng.");
            }


        }


    }

    public void OncolliderCars()
    {
        isCollided = true;

      //  Debug.Log("co chay ko.");
    }

}
