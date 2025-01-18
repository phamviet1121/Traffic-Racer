using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide_spone_map : MonoBehaviour
{
    public GameObject Spone_map;
    public float location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    { 
       

        if (other.gameObject.CompareTag("Player"))
        {
           
            Instantiate(Spone_map, new Vector3(0, 0, transform.position.z + location), Quaternion.identity);
        }
    }
}
