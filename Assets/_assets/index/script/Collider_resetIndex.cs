using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collider_resetIndex : MonoBehaviour
{
    public InfiniteMover infiniteMover;
    //public GameObject[] point;
    public UnityEvent<int,float> eventcollider;
    public int point;
    public float speed;

    public void resetcarai(int a,float b)
    {
        infiniteMover.Resetcar();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventcollider.Invoke(point, speed);
        }
    }

}
