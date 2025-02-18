using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collider_carAI : MonoBehaviour
{
    public string taggameObject;
    public UnityEvent collider_cars;
    public UnityEvent<Vector3> Player_collider_cars;
    public UnityEvent<Vector3> collider_cars_1_1;




    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag(taggameObject))
        {
            Vector3 contactPoint = collision.contacts[0].point;

            Player_collider_cars.Invoke(contactPoint);
            collider_cars.Invoke();

            StartCoroutine(DestroyCarAfterDelay(collision.gameObject, 2f));
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collider_cars.Invoke();

          
        }


    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("front_trigger"))
        {
            Vector3 contactPoint = other.ClosestPointOnBounds(transform.position);
            collider_cars_1_1.Invoke(contactPoint);


        }
    }
    private IEnumerator DestroyCarAfterDelay(GameObject car, float delay)
    {
       
        yield return new WaitForSeconds(delay);
        Destroy(car);
    }
    
   
}
