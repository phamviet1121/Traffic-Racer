using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_destroy : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("carAI"))
        {
            Destroy(other.gameObject);
        }
    }
}
