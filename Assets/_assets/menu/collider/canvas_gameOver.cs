using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class canvas_gameOver : MonoBehaviour
{
    public GameObject canvas_over;
    public GameObject canvas;

    public plus_point_control plus_point_control;

    public int total;
    public TextMeshProUGUI score_txt;
    public TextMeshProUGUI Total_money;

    public TextMeshProUGUI Total_distance;
    public TextMeshProUGUI Close;
    public TextMeshProUGUI keep;

    public TextMeshProUGUI Total_distance_money;
    public TextMeshProUGUI Close_money;
    public TextMeshProUGUI keep_money;
    public money_data money_data;

    bool congdiem= true;
    void Start()
    {
        // canvas_over.SetActive(false);
        congdiem = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void game_Over()
    {

        Debug.Log("da đ cgoij chua gameover");
        canvas_over.SetActive(true);
        canvas.SetActive(false);
        update_index_txt();
    }

    public void update_index_txt()
    {
        score_txt.text = plus_point_control.score.ToString();

        Total_distance.text = plus_point_control.distance.ToString("F2", new CultureInfo("fr-FR"));
        Close.text = plus_point_control.close_overtakes_index.ToString();
        keep.text = plus_point_control.speed_max_high_.ToString("F2", new CultureInfo("fr-FR"));

        Total_distance_money.text = ((int)(plus_point_control.distance * 25f)).ToString();
        Close_money.text = (plus_point_control.close_overtakes_index * 15).ToString();
        keep_money.text = ((int)(plus_point_control.speed_max_high_ * 7.5f)).ToString();
        // StartCounting(((int)(plus_point_control.distance * 2.5f)), Total_distance_money);
        // StartCounting((plus_point_control.close_overtakes_index * 15), Close_money);
        //  StartCounting((int)(plus_point_control.speed_max_high_ * 7.5f), keep_money);

        total = (int)(plus_point_control.distance * 25f) + (plus_point_control.close_overtakes_index * 15) + (int)(plus_point_control.speed_max_high_ * 7.5f);

        // StartCounting(total, Total_money);
        Total_money.text= total.ToString();

        if (congdiem==true)
        {
            StartCoroutine(delay_total(2f));
        }

        // StartCoroutine(CountAllNumbers());
    }

    private IEnumerator delay_total(float a)
    {


       // Debug.Log("sdfghjkllllllllllllllllllllllllllllllllllllllllllllll");
      
         money_data.money_iocn.icon_money += total;
     
        congdiem = false;
        yield return new WaitForSeconds(a);


        congdiem = true;

    }







    IEnumerator CountAllNumbers()
    {
        Debug.Log($"Total may co chay ko ");

        int distanceMoney = (int)(plus_point_control.distance * 2.5f);
        int closeMoney = plus_point_control.close_overtakes_index * 15;
        int keepMoney = (int)(plus_point_control.speed_max_high_ * 7.5f);

        Debug.Log($"Distance Money: {distanceMoney}");
        Debug.Log($"Close Money: {closeMoney}");
        Debug.Log($"Keep Money: {keepMoney}");
        Debug.Log($"Total: {total}");

        yield return StartCoroutine(CountUp(distanceMoney, Total_distance_money));
        yield return StartCoroutine(CountUp(closeMoney, Close_money));
        yield return StartCoroutine(CountUp(keepMoney, keep_money));
        yield return StartCoroutine(CountUp(total, Total_money));

       // money_data.money_iocn.icon_money += total;
    }

    IEnumerator CountUp(int targetValue, TextMeshProUGUI targetText)
    {
        float currentTime = 0f;
        int startValue = 0;
        float duration = 2f; // Thời gian chạy animation

        // Interpolates the value smoothly from 0 to target over time
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float progress = currentTime / duration;
            int currentValue = Mathf.RoundToInt(Mathf.Lerp(startValue, targetValue, progress));
            targetText.text = currentValue.ToString();
            Debug.Log($"Text {targetText.name} đang chạy: {currentValue} | currentTime: {currentTime}");
            yield return null;
        }

        // Ensures the final value is set correctly at the end of the animation
        targetText.text = targetValue.ToString();
        Debug.Log($"Text {targetText.name} hoàn thành: {targetValue}");
    }


    //public void StartCounting(int endValue, TextMeshProUGUI targetText)
    //{

    //    StartCoroutine(CountUp(endValue, targetText));
    //}

    //IEnumerator CountUp(int targetValue, TextMeshProUGUI targetText)
    //{
    //    float currentTime = 0f;
    //    int startValue = 0;

    //    while (currentTime < 2f)
    //    {
    //        currentTime += Time.deltaTime;
    //        int currentValue = Mathf.RoundToInt(Mathf.Lerp(startValue, targetValue, currentTime / 2f));
    //        targetText.text = currentValue.ToString();
    //        yield return null;
    //    }

    //    // Đảm bảo text hiển thị chính xác giá trị cuối
    //    targetText.text = targetValue.ToString();
    //}

}
