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

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(speedrandommin, speedrandommax);
        turnint = Random.Range(0, 3);

    }

   
    void Update()
    {
        if (!isCollided)
        {

            rb.velocity = new Vector3(0, 0, speed );
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

            speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 0.75f); 
            rb.velocity = new Vector3(0, 0, speed );

         
            if (speed <= 0.01f)
            {
                speed = 0f;
                enabled = false; 
             
            }


        }


    }

    public void OncolliderCars()
    {
        isCollided = true;

     
    }

}
