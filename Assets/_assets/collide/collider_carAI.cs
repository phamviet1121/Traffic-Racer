using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_carAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("back_trigger")|| other.gameObject.CompareTag("front_trigger") || other.gameObject.CompareTag("left_trigger") || other.gameObject.CompareTag("right_trigger"))
        {

            Destroy(other.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("back_trigger") || collision.gameObject.CompareTag("front_trigger") || collision.gameObject.CompareTag("left_trigger") || collision.gameObject.CompareTag("right_trigger"))
        {

            Destroy(collision.gameObject);
        }
    }
}
