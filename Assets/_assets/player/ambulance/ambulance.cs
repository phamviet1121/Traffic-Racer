using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambulance : MonoBehaviour
{
    public GameObject turn_left;
    public GameObject turn_right;
    public float blinkInterval = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BlinkCoroutine(turn_left, turn_right));
    }
    private IEnumerator BlinkCoroutine(GameObject signalA, GameObject signalB)
    {
        bool isAActive = true; // Biến để kiểm soát trạng thái nhấp nháy xen kẽ

        while (true) // Chạy vô hạn
        {
            signalA.SetActive(isAActive);
            signalB.SetActive(!isAActive);

            isAActive = !isAActive; // Đảo trạng thái nhấp nháy

            yield return new WaitForSeconds(blinkInterval);
        }
    }

}
