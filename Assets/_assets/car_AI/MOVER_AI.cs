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
    private float targetSpeed=0f;
    void Start()
    {
         speed = Random.Range(speedrandommin, speedrandommax);
       int turnint= Random.Range(0, 3);
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, 1f * speed * Time.deltaTime);
        if (turnint==1 && transform.position.x >= minX )
        {
            Debug.Log("rẽ trái");
            turnint = 0;
        }
        else if (turnint == 2 && transform.position.x <= maxX)
        {
            Debug.Log("rẽ phải");
            turnint = 0;
        }
       
    }

    public void OncolliderCars()
    {
        speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * 2f);
        Debug.Log($"{speed}");
    }

}
