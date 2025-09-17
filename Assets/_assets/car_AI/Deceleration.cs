using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deceleration : MonoBehaviour
{
    public GameObject carAI;
    private MOVER_AI mover_AI;
    private Coroutine resumeSpeedCoroutine;

    private HashSet<Collider> collidingObjects = new HashSet<Collider>();

    private void Start()
    {
        if (carAI != null)
        {
            mover_AI = carAI.GetComponent<MOVER_AI>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("carAI"))
        {
            collidingObjects.Add(other);
            CallBlockage();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("carAI"))
        {
            collidingObjects.Add(other); // bảo đảm vẫn còn trong vùng
            CallBlockage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("carAI"))
        {
            collidingObjects.Remove(other);

            // Nếu không còn đối tượng nào chạm nữa, bắt đầu đếm 5 giây
            if (collidingObjects.Count == 0 && resumeSpeedCoroutine == null)
            {
                resumeSpeedCoroutine = StartCoroutine(ResumeAfterDelay());
            }
        }
    }

    private void CallBlockage()
    {
        if (mover_AI != null)
        {
            mover_AI.Blockage_Ahead();

            // Nếu đang đếm ngược tăng tốc → hủy ngay
            if (resumeSpeedCoroutine != null)
            {
                StopCoroutine(resumeSpeedCoroutine);
                resumeSpeedCoroutine = null;
            }
        }
    }

    private IEnumerator ResumeAfterDelay()
    {
        float delay = 3f;
        float elapsed = 0f;

        while (elapsed < delay)
        {
            if (collidingObjects.Count > 0)
            {
                yield break; // Va chạm lại → dừng chờ
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        if (mover_AI != null)
        {
            mover_AI.ResumeSpeed();
        }

        resumeSpeedCoroutine = null;
    }
}
