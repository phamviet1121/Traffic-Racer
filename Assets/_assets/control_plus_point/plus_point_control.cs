using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Globalization;
using UnityEngine.UI;
using System;
using System.Reflection;
public class plus_point_control : MonoBehaviour
{
    public mover mover;
    public TextMeshProUGUI point;
    public TextMeshProUGUI obstaclePassCount_txt;

    public int obstaclesCleared = 0;
    public int close_overtakes_index;

    public int score = 0;
    private Coroutine resetCoroutine;
    public GameObject point_txt;

    public int plus_point;
    // private float speed_player;
    // private bool canIncreaseSpeed_player;

    public UnityEvent/*<float>*/ event_award;
    private UnityEngine.Color defaultColor;

    private float timer = 0f; // Bộ đếm thời gian
    private int scoreIncreaseRate = 1; // Mặc ịnh: tăng 0.1 điểm mỗi lần
    private float scoreUpdateInterval = 0.2f; // Khoảng thời gian cập nhật điểm
    private float lastScoreUpdateTime = 0f; // Lưu thời gian cập nhật điểm cuối cùng


    public GameObject obstaclePassCount_gameobject;
    public TextMeshProUGUI txt_speed;
    public TextMeshProUGUI distanceText;
    private Vector3 startPosition;
    public Transform player;
    public TextMeshProUGUI high_speed;
    public float speed_max_high;
    public float speed_max_high_;
    

    public float distance;
    public GameObject hight_speed;

    void Start()
    {
        // obstaclePassCount_txt.enabled = false;
        hight_speed.SetActive(false);
        obstaclePassCount_gameobject.SetActive(false);
        defaultColor = point.color;
        startPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(obstaclesCleared > close_overtakes_index)
        {
            close_overtakes_index = obstaclesCleared;
        }    


        // canIncreaseSpeed_player = mover.canIncreaseSpeed;
        //speed_player = mover.speed;


        timer += Time.deltaTime;
        if (mover.speed > 300 && mover.canIncreaseSpeed == true)
        {
            hight_speed.SetActive(true);
            speed_max_high = 0.3f;
        }
        else
        {
            hight_speed.SetActive(false);
            speed_max_high = 0f;
        }


        if (mover.speed > 200 && mover.canIncreaseSpeed == true)
        {
            point.color = UnityEngine.Color.green;
            scoreIncreaseRate = 2; // Cộng 0.5 điểm mỗi 0.2s

        }
        else if (mover.speed > 100 && mover.canIncreaseSpeed == true)
        {

            scoreIncreaseRate = 1; // Cộng 0.1 điểm mỗi 0.2s
           

        }
        else
        {
            point.color = defaultColor;
            scoreIncreaseRate = 0; // Không cộng điểm

        }


        if (mover.speed > 100 && Time.time - lastScoreUpdateTime >= scoreUpdateInterval)
        {
            speed_max_high_ += speed_max_high;
            score += scoreIncreaseRate;
            lastScoreUpdateTime = Time.time; // Cập nhật thời gian cộng điểm cuối cùng
        }


        distance = Vector3.Distance(startPosition, player.position) / 1000f; // Đổi sang km
        point.text = score.ToString();
        obstaclePassCount_txt.text = obstaclesCleared.ToString();
        txt_speed.text = ((int)(mover.speed / 2)).ToString();

        distanceText.text = distance.ToString("F2", new CultureInfo("fr-FR"));
        high_speed.text = speed_max_high_.ToString("F2", new CultureInfo("fr-FR"));

    }

    public void obstaclePassCount_lv5(Vector3 hitPosition, GameObject player)
    {
        if (mover.canIncreaseSpeed == true && mover.speed >= 200)
        {
            Collision_player_plus_point_lv5(hitPosition, player);
            mover.on_overtakeSound();
            event_award.Invoke();
        }
    }    

    public void obstaclePassCount(Vector3 hitPosition, GameObject player)
    {
        if (mover.canIncreaseSpeed == true && mover.speed >= 300)
        {
            point.enabled = true;

            obstaclePassCount_gameobject.SetActive(true);
            if (obstaclesCleared <= 3)
            {
                AddScore(100, hitPosition, player);
            }
            else
            {
                AddScore(120, hitPosition, player);
            }
        }

    }


    public void AddScore(int points, Vector3 hitPosition, GameObject player)
    {
        plus_point = Mathf.Min(plus_point + points, 540);
        obstaclesCleared++;
        score += plus_point;
        event_award.Invoke();
        // Nếu đã có một coroutine đang chạy, hủy nó để reset lại thời gian
        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }
        mover.on_overtakeSound();
        Collision_player_plus_point(hitPosition, player);
        resetCoroutine = StartCoroutine(ResetScoreAfterDelay(5f));
    }





    private IEnumerator ResetScoreAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        plus_point = 0;
        obstaclesCleared = 0; // Reset số lần ấn về 0

        //obstaclePassCount_txt.enabled = false;
        //Debug.Log("Score reset to 0 | Press Count reset to 0");
        obstaclePassCount_gameobject.SetActive(false);

    }




    public void Collision_player_plus_point(Vector3 hitPosition, GameObject player)
    {
        TextMeshPro tmp = point_txt.GetComponent<TextMeshPro>();



        tmp.text = "+ " + plus_point.ToString();
        Vector3 position_point_txt = new Vector3(player.transform.position.x, 30f, player.transform.position.z);
        if (hitPosition.x <= player.transform.position.x)
        {
            position_point_txt.x = player.transform.position.x - 5f;
        }
        else
        {
            position_point_txt.x = player.transform.position.x + 5f;
        }

        GameObject point_gameobject = Instantiate(point_txt, position_point_txt, Quaternion.identity);
        point_gameobject.transform.SetParent(player.transform);
    }


    public void Collision_player_plus_point_lv5(Vector3 hitPosition, GameObject player)
    {
        TextMeshPro tmp = point_txt.GetComponent<TextMeshPro>();



        tmp.text = "+ 75 <u>đ</u> ";
        Vector3 position_point_txt = new Vector3(player.transform.position.x, 30f, player.transform.position.z);
        if (hitPosition.x <= player.transform.position.x)
        {
            position_point_txt.x = player.transform.position.x - 5f;
        }
        else
        {
            position_point_txt.x = player.transform.position.x + 5f;
        }

        GameObject point_gameobject = Instantiate(point_txt, position_point_txt, Quaternion.identity);
        point_gameobject.transform.SetParent(player.transform);
    }
}
