using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class plus_point_control : MonoBehaviour
{
    public mover mover;
    public TextMeshProUGUI point;
    public TextMeshProUGUI obstaclePassCount_txt;
    public int obstaclesCleared = 0;
    public int score = 0;
    private Coroutine resetCoroutine;

    public GameObject point_txt;
    public int plus_point;
   // private float speed_player;
   // private bool canIncreaseSpeed_player;

    void Start()
    {
        obstaclePassCount_txt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        point.text = score.ToString();
        obstaclePassCount_txt.text = obstaclesCleared.ToString();
       // canIncreaseSpeed_player = mover.canIncreaseSpeed;
        //speed_player = mover.speed;
    }



    public void obstaclePassCount(Vector3 hitPosition, GameObject player)
    {
        if (mover.canIncreaseSpeed == true && mover.speed >= 300)
        {
            point.enabled = true;
            obstaclePassCount_txt.enabled = true;
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

        // Nếu đã có một coroutine đang chạy, hủy nó để reset lại thời gian
        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }

        Collision_player_plus_point(hitPosition, player);
        resetCoroutine = StartCoroutine(ResetScoreAfterDelay(5f));
    }





    private IEnumerator ResetScoreAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        plus_point = 0;
        obstaclesCleared = 0; // Reset số lần ấn về 0

        obstaclePassCount_txt.enabled = false;
        Debug.Log("Score reset to 0 | Press Count reset to 0");

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
}
