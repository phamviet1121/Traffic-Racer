using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class turn_L_R : MonoBehaviour
{
    public UnityEvent<bool> Event_turn;

    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("carAI"))
        {
            Event_turn.Invoke(true);
        }
        else
        {
            Event_turn.Invoke(false);
        }


    }
}
