using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_event : MonoBehaviour
{
    public GameObject[] stop;

    public GameObject TurnSignal_Left;
    public GameObject TurnSignal_Right;

    public GameObject lamp;

    public float blinkDuration = 3f; 
    public float blinkInterval = 0.2f; 
    void Start()
    {
        foreach (var item in stop)
        {
            item.SetActive(false);
        }
        TurnSignal_Left.SetActive(false);
        TurnSignal_Right.SetActive(false);
        lamp.SetActive(false);
    }    
    // khi sảy ra va chạm
    public void  OnCollision ()
    {
        onStop();
        StartCoroutine(ResetlampDelay(1f));
        StartBlinking();
    }    
    // bật phanh
    public void onStop()
    {
      
        foreach (var item in stop)
        {
            item.SetActive(true);
        }
       
        StartCoroutine( ResetStopDelay(2f));
    }
    private IEnumerator ResetStopDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (var item in stop)
        {
            item.SetActive(false);
        }

    }
    //đèn se nháy nháy 
    private IEnumerator ResetlampDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(BlinkCoroutine(lamp));

    }

    //xin nhan kép
    public void StartBlinking()
    {
        StartCoroutine(BlinkCoroutine(TurnSignal_Left));
        StartCoroutine(BlinkCoroutine(TurnSignal_Right));
    }

    
    //xin nhan bên trái
    public void OnTurnSignal_Left()
    {
        StartCoroutine(BlinkCoroutine(TurnSignal_Left));
    }
    //xin nhan bên phải
    public void OnTurnSignal_Right()
    {
        StartCoroutine(BlinkCoroutine(TurnSignal_Right));
    }
    
    private IEnumerator BlinkCoroutine(GameObject TurnSignal)
    {
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {

            TurnSignal.SetActive(!TurnSignal.activeSelf); 
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        TurnSignal.SetActive(false);
   
    }


}
