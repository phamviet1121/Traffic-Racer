using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class collider_randomTurnRate : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("carAI"))
        {
            GameObject car = other.gameObject;
            MOVER_AI mover = car.GetComponent<MOVER_AI>();
            mover.isCarApproaching = true;
        }
    }

}
