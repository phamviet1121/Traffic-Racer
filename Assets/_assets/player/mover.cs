using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float speed;
    public float speedTurm;

    public float accelerate;
    public float deceleration;
    public float speedRunTime;

    public GameObject navigation_car;
    public float minX; // Giới hạn biên trái
    public float maxX;  // Giới hạn biên phải

    private bool turnleft;
    private bool turnright;

    public float maxSpeed; // Tốc độ tối đa
    public float minSpeed;
    private float targetSpeed;

    private bool canIncreaseSpeed = true;

    public Rigidbody player_rb;
    private Rigidbody rb;


    public Transform vitri;
    void Start()
    {
        player_rb=GetComponent<Rigidbody>();
        GameObject B = GameObject.Find("oto");

        targetSpeed = minSpeed;
        if (B != null)
        {
            
            Transform A = B.transform.GetChild(0); // Giả sử A là child đầu tiên của B (cần kiểm tra lại logic nếu có nhiều child)
            navigation_car = B.transform.GetChild(0).gameObject;
            if (A != null)
            {
                rb = A.GetComponent<Rigidbody>(); // Chỉ lấy Rigidbody của A, bỏ qua các child của A
                if (rb != null)
                {
                    Debug.Log("Tìm thấy Rigidbody của A: " + A.gameObject.name);
                }
                else
                {
                    Debug.Log("A không có Rigidbody.");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Kiểm tra phím K để thay đổi tốc độ
        if (Input.GetKey(KeyCode.K) && canIncreaseSpeed)
        {
            // Nếu người chơi nhấn K, tăng dần tốc độ đến maxSpeed
            targetSpeed = maxSpeed;
            speedRunTime = accelerate;
        }
        else
        {
            if (!canIncreaseSpeed)
            {
                targetSpeed = minSpeed - 30;

                speedRunTime = 10f;
            }
            else
            {
                // Nếu không nhấn K, giảm tốc độ về minSpeed
                targetSpeed = minSpeed;
                speedRunTime = deceleration;
            }

        }
        if (Input.GetKey(KeyCode.J))
        {
            targetSpeed = minSpeed;
            speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * 5f);
        }
        else
        {
            speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * speedRunTime);
        }

        player_rb.velocity=new Vector3(0, 0, speed);




        //if (Input.GetKey(KeyCode.A) && turnleft&& canIncreaseSpeed)
        //{
        //    // navigation_car.transform.position += new Vector3(-1f * speedTurm * Time.deltaTime, 0, 0);
        //    rb.velocity = new Vector3(-speedTurm, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.D) && turnright&& canIncreaseSpeed)
        //{
        //    // navigation_car.transform.position += new Vector3(1f * speedTurm * Time.deltaTime, 0, 0);
        //    rb.velocity = new Vector3(speedTurm, 0f, 0f);
        //}
        ////transform.position += new Vector3(0, 0, 1f * speed * Time.deltaTime);
        //rb.velocity = new Vector3(0, 0, speed);
        Vector3 moveDirection = new Vector3(0, 0, speed);

        if (Input.GetKey(KeyCode.A) && turnleft )
        {
             moveDirection.x = -speedTurm;
            if(!canIncreaseSpeed)
            {
                moveDirection.x = -5;

            } 
          
        }
        else if (Input.GetKey(KeyCode.D) && turnright )
        {
            moveDirection.x = speedTurm;
            if (!canIncreaseSpeed)
            {
                moveDirection.x = 5;

            } 
            
        }
        else
        {
            moveDirection.x = 0f;
        }
        rb.velocity = moveDirection; // Gán giá trị cuối cùng




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

        if(position.z!=vitri.position.z&& canIncreaseSpeed)
        {
          
            position.z = Mathf.Lerp(position.z, vitri.position.z, Time.deltaTime * 5f);
            navigation_car.transform.position = position;
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
