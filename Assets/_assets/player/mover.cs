using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float speed;
    public float speedTurm;
    public GameObject navigation_car;
    public float minX; // Giới hạn biên trái
    public float maxX;  // Giới hạn biên phải

    private bool turnleft;
    private bool turnright;

    public float maxSpeed; // Tốc độ tối đa
    public float minSpeed;
    private float targetSpeed;

    private bool canIncreaseSpeed = true;
    void Start()
    {
        targetSpeed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra phím K để thay đổi tốc độ
        if (Input.GetKey(KeyCode.K) && canIncreaseSpeed)
        {
            // Nếu người chơi nhấn K, tăng dần tốc độ đến maxSpeed
            targetSpeed = maxSpeed;
        }
        else
        {
            if (!canIncreaseSpeed)
            {
                targetSpeed = minSpeed-30;
            }
            else
            {
                // Nếu không nhấn K, giảm tốc độ về minSpeed
                targetSpeed = minSpeed;
            }

        }

        // Lấy tốc độ thực tế với sự chuyển tiếp mượt mà
        speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * 5f);


        if (Input.GetKey(KeyCode.A) && turnleft)
        {
            navigation_car.transform.position += new Vector3(-1f * speedTurm * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && turnright)
        {
            navigation_car.transform.position += new Vector3(1f * speedTurm * Time.deltaTime, 0, 0);
        }
        transform.position += new Vector3(0, 0, 1f * speed * Time.deltaTime);


        Vector3 position = navigation_car.transform.position;

        // Giới hạn giá trị X trong khoảng [minX, maxX]
        position.x = Mathf.Clamp(position.x, minX, maxX);

        // Cập nhật lại vị trí của đối tượng
        navigation_car.transform.position = position;
        if (position.x <= minX)
        {
            turnleft = false;

        }
        else if (position.x >= maxX)
        {
            turnright = false;
        }
        else
        {
            turnleft = true;
            turnright = true;
        }
    }
    public void OncolliderCars()
    {

        if (speed - 30 <= 0)
        {
            speed = 0;
        }
        else
        {
            speed -= 30;
        }
        StartCoroutine(DisableSpeedIncrease(2f));
    }
    private IEnumerator DisableSpeedIncrease(float duration)
    {
        canIncreaseSpeed = false; // Tắt khả năng tăng tốc
        yield return new WaitForSeconds(duration); // Chờ trong 1 giây
        canIncreaseSpeed = true; // Bật lại khả năng tăng tốc
    }
}
