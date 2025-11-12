using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler_movercar : MonoBehaviour
{
    public GameObject[] points;
    public Rollingwheel rollingwheel;
   void Start()
    {
        moverpoint(0, 20);
    }    
    public void moverpoint(int point, float speed)
    {
        if (point < 0 || point >= points.Length) return;
        rollingwheel.acceleratewheelSpeed();
        StartCoroutine(MoveRoutine(point, speed));
        //if (point < 0 || point >= points.Length) return;
        //transform.position = Vector3.MoveTowards(transform.position, points[point].transform.position, speed * Time.deltaTime);
    }

    private IEnumerator MoveRoutine(int point, float speed)
    {
        Vector3 target = points[point].transform.position;

        // Lặp liên tục cho đến khi đến nơi
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );

            yield return null; // chờ frame tiếp theo
        }

        // đảm bảo đứng đúng vị trí
        transform.position = target;
        rollingwheel.resetwheelSpeed();
    }

}
