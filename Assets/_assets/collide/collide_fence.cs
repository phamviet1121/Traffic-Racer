using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide_fence : MonoBehaviour
{
    public float minX = -12f; // Giới hạn biên trái
    public float maxX = 12f;  // Giới hạn biên phải


    void Update()
    {
        // Lấy vị trí hiện tại của đối tượng
        Vector3 position = transform.position;

        // Giới hạn giá trị X trong khoảng [minX, maxX]
        position.x = Mathf.Clamp(position.x, minX, maxX);

        // Cập nhật lại vị trí của đối tượng
        transform.position = position;
    }

}
