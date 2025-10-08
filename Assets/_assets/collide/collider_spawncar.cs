using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.FilePathAttribute;

public class collider_spawncar : MonoBehaviour
{
    public int quantity_cars;
    public UnityEvent<int> sponecar_Event;


    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {

            sponecar_Event.Invoke(quantity_cars);
        }
    }

    public void detroygameobj()
    {
        Destroy(gameObject);
    }



}
