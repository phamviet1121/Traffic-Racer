using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detroy : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("da xoa chua");
            Destroy(gameObject);
         
        }
    }
}
