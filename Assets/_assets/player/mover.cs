using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    public bool canIncreaseSpeed = true;

    public Rigidbody player_rb;
    private Rigidbody rb;


    public Transform vitri;

    public GameObject explosion;

    public bool gameover = false;
    void Start()
    {
        control_Rb();
    }
    // Update is called once per frame
    void Update()
    {
        accelerate_deceleration_cars();


        Vector3 moveDirection = new Vector3(0, 0, speed);

     

        if (Input.GetKey(KeyCode.A) && turnleft)
        {
            moveDirection.x = -speedTurm;
            if (!canIncreaseSpeed)
            {
                moveDirection.x = -5;

            }

        }
        else if (Input.GetKey(KeyCode.D) && turnright)
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

        if (!gameover)
        {
            rb.velocity = moveDirection;
        }
        else
        {
            Debug.Log("mayf cos chay ko may dung lai chua ha");
            rb.velocity = new Vector3(0, 0, 0);
            navigation_car.transform.position = navigation_car.transform.position;
        }
        // Gán giá trị cuối cùng



        correct_location();

        player_rb.velocity = new Vector3(0, 0, speed);





    }
    public void OncolliderCars(Vector3 contactPoint)
    {

        if (speed - 30 <= 0)
        {
            speed = 0;
        }
        else
        {
            speed -= 30;
        }
        StartCoroutine(DisableSpeedIncrease(1.5f, contactPoint));
    }
    private IEnumerator DisableSpeedIncrease(float duration,Vector3 contactPoint)
    {
        if (speed <= 300)
        {
            canIncreaseSpeed = false;
            yield return new WaitForSeconds(duration);
            canIncreaseSpeed = true;
        }
        else
        {

            gameover = true;
            navigation_car.transform.SetParent(null);

            //// Giữ nguyên vị trí hiện tại của A
            //navigation_car.transform.position = navigation_car.transform.position;
            Instantiate(explosion, new Vector3 (contactPoint.x, 10f, contactPoint.z), Quaternion.identity);

            //navigation_car.transform.position = navigation_car.transform.position;
            yield return new WaitForSeconds(duration);
            Time.timeScale = 0;
        }

    }
    private IEnumerator DisableSpeedIncreaseFence(float duration)
    {

        canIncreaseSpeed = false;
        yield return new WaitForSeconds(duration);
        canIncreaseSpeed = true;


    }

    public void correct_location()
    {
        Vector3 position = navigation_car.transform.position;

        // Giới hạn giá trị X trong khoảng [minX, maxX]
        position.x = Mathf.Clamp(position.x, minX, maxX);

        // Cập nhật lại vị trí của đối tượng
        navigation_car.transform.position = position;
        if (position.x <= minX)
        {
            if (turnleft)
            {
                StartCoroutine(DisableSpeedIncreaseFence(0.1f));
            }
            turnleft = false;

        }
        else if (position.x >= maxX)
        {
            if (turnright)
            {
                StartCoroutine(DisableSpeedIncreaseFence(0.1f));
            }
            turnright = false;
        }
        else
        {
            turnleft = true;
            turnright = true;
        }

        if (position.z != vitri.position.z && canIncreaseSpeed)
        {
            if (!gameover)
            {

                position.z = Mathf.Lerp(position.z, vitri.position.z, Time.deltaTime * 5f);
                navigation_car.transform.position = position;
            }

        }
    }    
    public void turn(Vector3 moveDirection)
    {
        if (Input.GetKey(KeyCode.A) && turnleft)
        {
            moveDirection.x = -speedTurm;
            if (!canIncreaseSpeed)
            {
                moveDirection.x = -5;

            }

        }
        else if (Input.GetKey(KeyCode.D) && turnright)
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
    }    
    public void accelerate_deceleration_cars()
    {

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
            if (gameover)
            {
                speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 0.5f);
            }
            else
            {
                speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * speedRunTime);
            }

        }
    }

    public void control_Rb()
    {
        player_rb = GetComponent<Rigidbody>();
        GameObject B = GameObject.Find("oto");

        targetSpeed = minSpeed;
        if (B != null)
        {

            Transform A = B.transform.GetChild(0); // Giả sử A là child đầu tiên của B (cần kiểm tra lại logic nếu có nhiều child)
            navigation_car = B.transform.GetChild(0).gameObject;
            if (A != null)
            {
                rb = A.GetComponent<Rigidbody>(); // Chỉ lấy Rigidbody của A, bỏ qua các child của A
                                                  //if (rb != null)
                                                  //{
                                                  //    Debug.Log("Tìm thấy Rigidbody của A: " + A.gameObject.name);
                                                  //}
                                                  //else
                                                  //{
                                                  //    Debug.Log("A không có Rigidbody.");
                                                  //}
            }
        }
    }    


}
