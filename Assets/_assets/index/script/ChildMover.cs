using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMover : MonoBehaviour
{
    public float speedZ = 2f; // tốc độ giảm Z mỗi giây

    // Update di chuyển Z giảm dần
    private void Update()
    {
        Vector3 localPos = transform.localPosition;
        localPos.z += speedZ * Time.deltaTime;
        transform.localPosition = localPos;
    }

    // Hàm reset Z về 0 (relative so với parent)
    public void ResetZ()
    {
        Vector3 localPos = transform.localPosition;
        localPos.z = 0f;
        transform.localPosition = localPos;
    }
}
