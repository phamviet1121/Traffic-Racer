using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserRAycast_player : MonoBehaviour
{
    public float rayDistance = 10f;
    public GameObject[] lights;
    public bool onlight;


    void Update()
    {

        if (onlight)
        {

            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.CompareTag("carAI"))
                {

                    MOVER_AI MOVER_AI = hit.collider.GetComponent<MOVER_AI>();

                    if (MOVER_AI != null)
                    {
                        MOVER_AI.turn_control();
                    }
                }
            }
        }
        else
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
        }


    }
}
