using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collider_carAI : MonoBehaviour
{
    public string taggameObject;
    public UnityEvent collider_cars;
   


    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag(taggameObject))
        {
           collider_cars.Invoke();
           
           

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("event");
            collider_cars.Invoke();



        }
    }
   
   
    public void destroyCar()
    {
     

    }
}
