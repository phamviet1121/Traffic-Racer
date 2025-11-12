using System.Collections.Generic;
using UnityEngine;

public class InfiniteMoverManager : MonoBehaviour
{
    public List<Transform> objects;   // 3 vật của bạn
    public Transform pointB;
    public float speed;

    // Đưa object xuống cuối danh sách
    public void MoveToLast(Transform obj)
    {
        objects.Remove(obj);
        objects.Add(obj);
    }
}
