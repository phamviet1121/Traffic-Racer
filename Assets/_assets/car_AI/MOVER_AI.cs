using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MOVER_AI : MonoBehaviour
{
    public float speedrandommax;
    public float speedrandommin;
    public float minX;
    public float maxX;
    public float speed;
    float speed_;
    //int turnint;


    private Rigidbody rb;
    private bool turn_left_right = false;
    // private bool turn_right;
    private bool isMoving = false; // Flag to track whether the object is moving
                                   //  private bool blockageStatus = false;
    public bool on_left_turn;
    public bool on_right_turn;

    public bool isCollided = false;
    public bool isDeceleration = false;
    public bool isResuming = false;



    private Coroutine resetSpeedCoroutine;
    //public control_rollingwheel control_rollingwheel;

    public UnityEvent event_turrn_left;
    public UnityEvent event_turrn_right;

    public UnityEvent event_mover;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(speedrandommin, speedrandommax);
        // turnint = Random.Range(0, 3);

    }


    void Update()
    {

        event_mover.Invoke();
        //if (control_rollingwheel != null)
        //{
        //    control_rollingwheel.rotationSpeed = speed;
        //}

    }

    public void Mover_carAI()
    {
        // giảm tốc về 0 
        if (isCollided)
        {

            // Giảm tốc về 0
            speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 0.75f);
            rb.velocity = new Vector3(0, 0, speed);

            if (speed <= 0.01f)
            {
                speed = 0f;
                rb.velocity = Vector3.zero;
                enabled = false; // Dừng cập nhật nếu muốn
            }
        }
        else
        {

            //giảm tốc
            if (isDeceleration)
            {
                speed = Mathf.Lerp(speed, speedrandommin - 10f, Time.deltaTime * 5f);
                rb.velocity = new Vector3(0, 0, speed);
                if (speed <= speedrandommin - 10f)
                {
                    speed = speedrandommin - 10f;
                    // isDeceleration = false;

                }
            }  //tăng tốc  
            else if (isResuming)
            {
                speed_ = Random.Range(speedrandommin, speedrandommax);
                // Tăng tốc lại
                speed = Mathf.Lerp(speed, speed_, Time.deltaTime * 0.75f);
                rb.velocity = new Vector3(0, 0, speed);

                if (speed >= speed_ - 0.01f)
                {
                    speed = speed_;
                    isResuming = false;
                }
            }
            //tóc độ nình thường
            else
            {
                // Di chuyển bình thường
                rb.velocity = new Vector3(0, 0, speed);
            }
        }

    }
    public void Blockage_Ahead()
    {
       
        isDeceleration = true;

    }
    public void ResumeSpeed()
    {
        isResuming = true;
        isDeceleration = false;
    }
    public void Mover_carAI_1_1()
    {

        if (!isCollided)
        {

            rb.velocity = new Vector3(0, 0, -speed);

        }
        else
        {

            speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 0.75f);
            rb.velocity = new Vector3(0, 0, -speed);


            if (speed <= 0.01f)
            {
                speed = 0f;
                enabled = false;

            }


        }

    }


    private IEnumerator MoveToTarget(float targetX)
    {
        float startX = transform.position.x;
        float timeElapsed = 0f;

        while (timeElapsed < 1f) // Move smoothly over time
        {
            transform.position = new Vector3(Mathf.Lerp(startX, targetX, timeElapsed), transform.position.y, transform.position.z);
            timeElapsed += Time.deltaTime * 0.38f; // Adjust the speed factor here if needed
            yield return null; // Wait until the next frame
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z); // Ensure final position
        isMoving = false; // Reset the moving flag after the movement is complete
    }




    public void OncolliderCars()
    {
        isCollided = true;


    }



    public void Blockage_left(bool turn)
    {
        on_left_turn = turn;
        //  Debug.Log($"rex trai {on_left_turn}");
    }
    public void Blockage_right(bool turn)
    {
        // Debug.Log($"rex phai {on_right_turn}");
        on_right_turn = turn;
    }

    public void turn_control()
    {
        ////turn_left_right = true;
        if (/*turn_left_right &&*/ !isMoving) // Check if the object is ready to move
        {
            isMoving = true; // Set moving flag to true
            Debug.Log($"{transform.position.x}");
            if (!on_left_turn && !on_right_turn)
            {

                if (transform.position.x >= minX + 27f && transform.position.x <= maxX - 27f)
                {
                    float targetX;
                    float x = Random.Range(0f, 1f);
                    if (x > 0.5f)
                    {
                        event_turrn_right.Invoke();
                        targetX = transform.position.x + 27f;
                    }
                    else
                    {
                        event_turrn_left.Invoke();
                        targetX = transform.position.x - 27f;
                    }

                    StartCoroutine(MoveToTarget(targetX));
                }
                else if (transform.position.x < maxX - 1f && !on_right_turn)
                {
                    event_turrn_right.Invoke();

                    StartCoroutine(MoveToTarget(transform.position.x + 27f));

                }
                else if (transform.position.x > minX + 1f && !on_left_turn)
                {
                    event_turrn_left.Invoke();

                    StartCoroutine(MoveToTarget(transform.position.x - 27f));

                }
                else
                {
                    isMoving = false;
                }
            }
            else if (on_left_turn && !on_right_turn)
            {
                if (transform.position.x < maxX - 1f)
                {
                    event_turrn_right.Invoke();

                    StartCoroutine(MoveToTarget(transform.position.x + 27f));

                }
                else
                {
                    isMoving = false;
                }
            }
            else if (!on_left_turn && on_right_turn)
            {
                if (transform.position.x > minX + 1f)
                {
                    event_turrn_left.Invoke();

                    StartCoroutine(MoveToTarget(transform.position.x - 27f));

                }
                else
                {
                    isMoving = false;
                }
            }
            else
            {
                isMoving = false;
            }

        }


    }
}
