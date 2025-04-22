using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class mode : MonoBehaviour
{
    public int index_Mode;
    public UnityEvent<int> UnityEvent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onclick()
    {
        UnityEvent.Invoke(index_Mode);
    }    
}
