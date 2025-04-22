using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimePlay : MonoBehaviour
{
    public TextMeshProUGUI timePlayerTxt;
    //public GameObject gameOverPanel; // Bảng Game Over
    public float extraPlayTime;
    public float countdownTime;
    public float startTime;

    private bool isGameOver = false;
    private Color defaultColor;
    public UnityEvent event_over;
    void Start()
    {
        countdownTime = startTime;
        defaultColor = timePlayerTxt.color;
        // gameOverPanel.SetActive(false); // Ẩn UI Game Over khi bắt đầu
    }

    void Update()
    {
        if (isGameOver) return;

        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            timePlayerTxt.text = countdownTime.ToString("F2"); // Hiển thị 2 chữ số thập phân
            if (countdownTime <5f)
            {
                timePlayerTxt.color = Color.red; // Màu bình thường

            }
            else
            {
                timePlayerTxt.color = defaultColor;
            }
        }
        else
        {
            countdownTime = 0;
            StartCoroutine(GameOverRoutine(0.5f));
        }
    }

    private IEnumerator GameOverRoutine(float delay)
    {
        isGameOver = true;
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0;
        event_over.Invoke();
       // gameOverPanel.SetActive(true); // Hiển thị giao diện Game Over
    }

    public void ExtraTime()
    {
        if (!isGameOver)
        {
            countdownTime += extraPlayTime;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        isGameOver = false;
        countdownTime = startTime;
        //gameOverPanel.SetActive(false);
    }
}
