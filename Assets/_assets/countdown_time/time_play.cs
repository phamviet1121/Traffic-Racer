using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimePlay : MonoBehaviour
{
    public TextMeshProUGUI timePlayerTxt;
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
    }

    void Update()
    {
        if (isGameOver) return;

        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            timePlayerTxt.text = countdownTime.ToString("F2"); 
            if (countdownTime <5f)
            {
                timePlayerTxt.color = Color.red; 

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
    }
}
