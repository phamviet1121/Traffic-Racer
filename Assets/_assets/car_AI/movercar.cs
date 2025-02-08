using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movercar : MonoBehaviour
{
    private Rigidbody rb;
    public float speed=5f;
    public float tunrspeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("có di chuyen ko ");
            // transform.position += new Vector3(0f,0f, speed*Time.deltaTime);
            rb.velocity = new Vector3(0f, 0f, speed);
        }
        else

        {
            rb.velocity = Vector3.zero;
        }
       
    }
}