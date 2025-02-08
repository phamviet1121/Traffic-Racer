using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_camara : MonoBehaviour
{
    public float speedCamara;
    public mover mover;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedCamara = mover.speed;
        transform.position += new Vector3(0, 0, 1f * speedCamara * Time.deltaTime);
        //neu car bi destroy thi speedcamara giam dan ve 0
    }
}
