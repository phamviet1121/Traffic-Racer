using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float speed;
    public GameObject navigation_car;
    public float minX ; // Giới hạn biên trái
    public float maxX ;  // Giới hạn biên phải

    private bool turnleft;
    private bool turnright;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.A) && turnleft)
        {
            navigation_car.transform.position += new Vector3(-1f * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)&& turnright)
        {
            navigation_car.transform.position += new Vector3(1f * speed * Time.deltaTime, 0, 0);
        }
        transform.position += new Vector3(0, 0, 1f*speed*Time.deltaTime );


        Vector3 position = navigation_car.transform.position;

        // Giới hạn giá trị X trong khoảng [minX, maxX]
        position.x = Mathf.Clamp(position.x, minX, maxX);

        // Cập nhật lại vị trí của đối tượng
        navigation_car.transform.position = position;
        if(position.x<= minX)
        {
            turnleft = false;

        }
        else if(position.x>=maxX)
        {
            turnright = false;
        }
        else
        {
            turnleft = true;
            turnright = true;
        }
    }

}
