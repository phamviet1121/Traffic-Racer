using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brake_suddenly : MonoBehaviour
{
    public GameObject brake_suddenly_left;
    public GameObject brake_suddenly_right;
    void Start()
    {
        brake_suddenly_left.SetActive(false);
        brake_suddenly_right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void turn_suddenly_left()
    {
        brake_suddenly_right.SetActive(true);
        StartCoroutine(Reset_Turn_suddenly_Delay(0.2f, brake_suddenly_right));
    }
    public void turnle_suddenly_right()
    {
        brake_suddenly_left.SetActive(true);
        StartCoroutine(Reset_Turn_suddenly_Delay(0.2f, brake_suddenly_left));
    }
    public void brake()
    {
        brake_suddenly_right.SetActive(true);
        brake_suddenly_left.SetActive(true);
        StartCoroutine(Reset_Turn_suddenly_Delay(0.2f, brake_suddenly_left));
        StartCoroutine(Reset_Turn_suddenly_Delay(0.2f, brake_suddenly_right));
    }

    private IEnumerator Reset_Turn_suddenly_Delay(float delay, GameObject turnle_suddenly)
    {

        yield return new WaitForSeconds(delay);
        turnle_suddenly.SetActive(false);



    }
}
