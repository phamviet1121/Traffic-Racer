using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfiniteMover : MonoBehaviour
{
    private float speed ;
    public float spacing = 320f; 
    private InfiniteMoverManager manager;
    public UnityEvent eventReset;

    private void Start()
    {
        manager = FindAnyObjectByType<InfiniteMoverManager>();
        speed=manager.speed;
    }

    private void Update()
    {
        if (manager == null || manager.objects.Count == 0) return;

        // Di chuyển từ A → B
        transform.position = Vector3.MoveTowards(
            transform.position,
            manager.pointB.position,
            speed * Time.deltaTime
        );

        // Khi tới B thì nhảy xuống cuối danh sách
        if (Vector3.Distance(transform.position, manager.pointB.position) < 0.1f)
        {
            MoveToBack();
        }

        // --- KIỂM TRA VÀ ĐIỀU CHỈNH KHOẢNG CÁCH Z ---
        int index = manager.objects.IndexOf(transform);

        // Nếu không phải vật đầu tiên trong list
        if (index > 0)
        {
            Transform prevObj = manager.objects[index - 1];
            float currentSpacing = transform.position.z - prevObj.position.z;

            // Nếu lệch spacing thì điều chỉnh lại
            if (Mathf.Abs(currentSpacing - spacing) > 0.01f)
            {
                Vector3 pos = transform.position;
                pos.z = prevObj.position.z + spacing;
                transform.position = pos;
            }
        }
    }

    void MoveToBack()
    {
        // Lấy object cuối
        Transform lastObj = manager.objects[manager.objects.Count - 1];

        // Nếu chính nó đang là cuối thì lấy object trước
        if (lastObj == this.transform && manager.objects.Count > 1)
        {
            lastObj = manager.objects[manager.objects.Count - 2];
        }

        // Tính toán vị trí Z mới: luôn lastObj.z + spacing
        float newZ = lastObj.position.z + spacing;

        // Đặt lại vị trí
        transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            newZ
        );

        // Đưa xuống cuối list
        manager.MoveToLast(transform);
        Resetcar();
    }
    public void Resetcar()
    {
        eventReset.Invoke();
    }
}
