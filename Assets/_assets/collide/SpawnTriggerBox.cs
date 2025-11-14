using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class SpawnTriggerBox : MonoBehaviour
{
    public GameObject boxspams;
    public GameObject locationSpamBox;
    GameObject boxnew;

    public void SpawnBox()
    {
       Instantiate(boxspams, locationSpamBox.transform.position, Quaternion.identity);
    }
    public void SpamBox_2()
    {
        if(boxnew!=null)
        {
            Destroy(boxnew);
        }
        boxnew=Instantiate(boxspams, locationSpamBox.transform.position, Quaternion.identity);
    }

}
