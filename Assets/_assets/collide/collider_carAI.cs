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

            StartCoroutine(DestroyCarAfterDelay(collision.gameObject, 2f));
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collider_cars.Invoke();

          
        }
    }

    private IEnumerator DestroyCarAfterDelay(GameObject car, float delay)
    {
        Debug.Log("có xóa ko ");
        yield return new WaitForSeconds(delay);
        Destroy(car);
    }
    
}
