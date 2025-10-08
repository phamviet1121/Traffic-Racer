using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class SpawnTriggerBox : MonoBehaviour
{
    public GameObject boxspams;
    public GameObject locationSpamBox;

    public void SpawnBox()
    {
        Instantiate(boxspams, locationSpamBox.transform.position, Quaternion.identity);
    }
}
