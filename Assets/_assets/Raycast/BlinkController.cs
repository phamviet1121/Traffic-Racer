using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
    public float StartTime = 3f;
    public float DelayTime = 0.2f;
    private bool runTime_bool;
    public float delay;



    IEnumerator Blink(GameObject gameobj)
    {
        runTime_bool = true;
        float elapsedTime = 0f;
        Blink_obj blink_obj = gameobj.GetComponent<Blink_obj>();

        while (elapsedTime < StartTime)
        {
            foreach (var obj in blink_obj.obj)
            {
                obj.SetActive(false);
            }

            yield return new WaitForSeconds(DelayTime / 2f);

            foreach (var obj in blink_obj.obj)
            {
                obj.SetActive(true);
            }
            yield return new WaitForSeconds(DelayTime / 2f);

            elapsedTime += DelayTime;
        }

        // Đảm bảo object bật lại sau cùng
        foreach (var obj in blink_obj.obj)
        {
            obj.SetActive(true);
        }

        runTime_bool = false;
    }
    public void runblink_gameobj(GameObject gameobj)
    {
        if (!runTime_bool)
        {
            StartCoroutine(DelayedBlink(gameobj, delay));
        }

    }
    private IEnumerator DelayedBlink(GameObject gameobj, float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(Blink(gameobj));
    }
    ////
    ///



    IEnumerator BlinkcarAI(GameObject gameobj)
    {
        runTime_bool = true;
        float elapsedTime = 0f;
         Blink_obj blink_obj = gameobj.GetComponent<Blink_obj>();

        while (elapsedTime < StartTime)
        {
            foreach (MeshRenderer mr in blink_obj.meshRenderers)
            {
                if (mr != null)
                {
                    mr.enabled = false; // Tắt hiển thị
                }
            }
           // gameobj.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(DelayTime / 2f);

            foreach (MeshRenderer mr in blink_obj.meshRenderers)
            {
                if (mr != null)
                {
                    mr.enabled = true; // Tắt hiển thị
                }
            }
           // gameobj.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(DelayTime / 2f);

            elapsedTime += DelayTime;
        }

        // Đảm bảo object bật lại sau cùng
        foreach (MeshRenderer mr in blink_obj.meshRenderers)
        {
            if (mr != null)
            {
                mr.enabled = true; // Tắt hiển thị
            }
        }
       // gameobj.GetComponent<MeshRenderer>().enabled = true;

        runTime_bool = false;
    }
    public void runblink_gameobj_carAI(GameObject gameobj)
    {
        if (!runTime_bool)
        {
            StartCoroutine(DelayedBlinkcarAI(gameobj, delay));
        }

    }
    private IEnumerator DelayedBlinkcarAI(GameObject gameobj, float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(BlinkcarAI(gameobj));
    }

}
