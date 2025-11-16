using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mover : MonoBehaviour
{
    public float speed;
    public float speedTurm;

    public float accelerate;
    public float deceleration;
    public float speedRunTime;

    public GameObject navigation_car;
    public float minX; 
    public float maxX;  

    private bool turnleft;
    private bool turnright;

    public float maxSpeed; 
    public float minSpeed;
    private float targetSpeed;

    public bool canIncreaseSpeed = true;

    public Rigidbody player_rb;
    private Rigidbody rb;


    public Transform vitri;

    public GameObject explosion;

    public bool gameover = false;
    public TurnSignal turnSignalScript;

    brake_suddenly brake_suddenlyScript;
    control_rollingwheel control_rollingwheelScript;
    public BlinkController BlinkController;
    public Cars_sound cars_soundScript;

    bool accelerate_Inactive;
    bool deceleration_Inactive;
    bool hasCheckedBrake_left;
    bool hasCheckedBrake_right;
    bool hasCheckedBrake;

    public UnityEvent Spamplayer;
    public bool spam_car_player;




    private bool isAccelerating;
    private bool isDecelerating;
    public Vector3 moveDirection;

    public bool input_left;
    public bool input_right;

    private bool isAchievements100;
    private float timeAtHighSpeed100=0f;
    private bool isAchievements120;
    private float timeAtHighSpeed120 = 0f;
    private bool isAchievements150;
    private float timeAtHighSpeed150 = 0f;
    private bool isAchievements175;
    private float timeAtHighSpeed175 = 0f;
    private bool isAchievements240;
    private float timeAtHighSpeed240 = 0f;


    public UnityEvent event_gameOver;
    public UnityEvent event_startgame;
    void Start()
    {
        spam_car_player = true;
        Spamplayer.Invoke();
        control_Rb();
        input_left = false;
        input_right = false;
        isAchievements100 = true;

    }
    // Update is called once per frame
    void Update()
    {
        accelerate_deceleration_cars();

        a();

        correct_location();

        player_rb.velocity = new Vector3(0, 0, speed);
        control_rollingwheelScript.rotationSpeed = speed;


        AchievementsUnlock();


    }
    private void AchievementsUnlock()
    {
        if (speed >= 100)
        {
            timeAtHighSpeed100 += Time.deltaTime;
            if (isAchievements100 && timeAtHighSpeed100 >= 30f)
            {
                GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQAQ");
                isAchievements100 = false;
            }
        }
        else
        {
            timeAtHighSpeed100 = 0f;
        }


        if (speed >= 120)
        {
            timeAtHighSpeed120 += Time.deltaTime;
            if (isAchievements120 && timeAtHighSpeed120 >= 30f)
            {
                GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQAg");
                isAchievements120 = false;
            }
        }
        else
        {
            timeAtHighSpeed120 = 0f;
        }


        if (speed >= 150)
        {
            timeAtHighSpeed150 += Time.deltaTime;
            if (isAchievements150 && timeAtHighSpeed150 >= 30f)
            {
                GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQAw");
                isAchievements150 = false;
            }
        }
        else
        {
            timeAtHighSpeed150 = 0f;
        }

        if (speed >= 175)
        {
            timeAtHighSpeed175 += Time.deltaTime;
            if (isAchievements175 && timeAtHighSpeed175 >= 60f)
            {
                GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQBA");
                isAchievements175 = false;
            }
        }
        else
        {
            timeAtHighSpeed175 = 0f;
        }

        if (speed >= 240)
        {
            timeAtHighSpeed240 += Time.deltaTime;
            if (isAchievements240 && timeAtHighSpeed240 >= 180f)
            {
                GooglePlayManager.Instance.UnlockAchievement("CgkIhtTcqpkdEAIQBQ");
                isAchievements240 = false;
            }
        }
        else
        {
            timeAtHighSpeed240 = 0f;
        }
    }    


    public void input_getkey_left()
    {

        input_left = true;


    }
    public void getkeyup_left()
    {
        hasCheckedBrake_left = false;
        input_left = false;
        turnSignalScript.offTurnLeft();
    }

    public void input_getkey_right()
    {

        input_right = true;


    }
    public void getkeyup_right()
    {
        hasCheckedBrake_right = false;
        input_right = false;
        turnSignalScript.offTurnRight();
    }

    public void A1()
    {

        // moveDirection = new Vector3(0, 0, speed);
        // Vector3 moveDirection = new Vector3(0, 0, speed);
        if (input_left && turnleft)
        {
            //input_left = true;
            moveDirection.x = -speedTurm;
            if (!canIncreaseSpeed)
            {
                moveDirection.x = -5;

            }
            turnSignalScript.StartTurnLeft();

            if (!hasCheckedBrake_left)
            {
                hasCheckedBrake_left = true; // Đánh dấu đã kiểm tra
                if (speed >= 250)
                {
                    brake_suddenlyScript.turn_suddenly_left();
                    cars_soundScript.onDriftSound();

                }
            }
            Debug.Log("may chyaj nhieeuf thees HAM AN DAY NE");
        }

    }
    public void A2()
    {
        //moveDirection = new Vector3(0, 0, speed);
        // Vector3 moveDirection = new Vector3(0, 0, speed);
        if (input_right && turnright)
        {
            // input_right = true;
            moveDirection.x = speedTurm;
            if (!canIncreaseSpeed)
            {
                moveDirection.x = 5;

            }
            turnSignalScript.StartTurnRighgt();

            if (!hasCheckedBrake_right)
            {
                hasCheckedBrake_right = true; // Đánh dấu đã kiểm tra
                if (speed >= 250)
                {
                    brake_suddenlyScript.turnle_suddenly_right();
                    cars_soundScript.onDriftSound();
                }
            }
        }

    }
    public void a()
    {
        Vector3 moveDirection = new Vector3(0, 0, speed);
        if (input_left && turnleft)
        {

            moveDirection.x = -speedTurm;
            if (!canIncreaseSpeed)
            {
                moveDirection.x = -5;

            }
            turnSignalScript.StartTurnLeft();

            if (!hasCheckedBrake_left)
            {
                hasCheckedBrake_left = true; // Đánh dấu đã kiểm tra
                if (speed >= 250)
                {
                    brake_suddenlyScript.turn_suddenly_left();
                    cars_soundScript.onDriftSound();
                }
            }

        }
        else if (input_right && turnright)
        {

            moveDirection.x = speedTurm;
            if (!canIncreaseSpeed)
            {
                moveDirection.x = 5;

            }
            turnSignalScript.StartTurnRighgt();

            if (!hasCheckedBrake_right)
            {
                hasCheckedBrake_right = true; // Đánh dấu đã kiểm tra
                if (speed >= 250)
                {
                    brake_suddenlyScript.turnle_suddenly_right();
                    cars_soundScript.onDriftSound();
                }
            }
        }
        else
        {
            moveDirection.x = 0f;
            turnSignalScript.Inactive_Turn();
        }
        if (!gameover)
        {
            rb.velocity = moveDirection;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            navigation_car.transform.position = navigation_car.transform.position;
        }

        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    hasCheckedBrake_left = false;
        //}
        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    hasCheckedBrake_right = false;
        //}

    }

    public void input_getkey_Accelerating()
    {
        isAccelerating = true;
    }
    public void getup_Accelerating()
    {
        isAccelerating = false;
    }
    public void input_getkey_isDecelerating()
    {
        isDecelerating = true;
    }
    public void getup_isDecelerating()
    {
        isDecelerating = false;
        hasCheckedBrake = false;
    }



    bool hasWrongWayCrash = false;
    public void OnWrongWayCollision()
    {
        hasWrongWayCrash = true;
    }


    //map_1_1
    public void l_v_2_OncolliderCars(Vector3 contactPoint)
    {

        StartCoroutine(DisableSpeedIncrease_1_1(1.5f, contactPoint));
    }
    private IEnumerator DisableSpeedIncrease_1_1(float duration, Vector3 contactPoint)
    {
        cars_soundScript.stoptRunCarSound();
        cars_soundScript.onbigcrashSound();
        gameover = true;
        navigation_car.transform.SetParent(null);


        Instantiate(explosion, new Vector3(contactPoint.x, 10f, contactPoint.z), Quaternion.identity);


        yield return new WaitForSeconds(duration);
        event_gameOver.Invoke();
        Time.timeScale = 0;


    }

    public void l_v_3_OncolliderCars(Vector3 contactPoint)
    {
        if (speed - 30 <= 0)
        {
            speed = 0;
        }
        else
        {
            speed -= 30;
        }

        BlinkController.runblink_gameobj(navigation_car);

        StartCoroutine(DisableSpeedIncrease_1_2(1.5f, contactPoint));
    }
    private IEnumerator DisableSpeedIncrease_1_2(float duration, Vector3 contactPoint)
    {
        if (speed <= 300)
        {

            cars_soundScript.onCrashSound();
            canIncreaseSpeed = false;
            yield return new WaitForSeconds(duration - 1f);
            canIncreaseSpeed = true;



        }
        else
        {
            cars_soundScript.stoptRunCarSound();
            cars_soundScript.onbigcrashSound();
            gameover = true;
            navigation_car.transform.SetParent(null);

            //// Giữ nguyên vị trí hiện tại của A
            //navigation_car.transform.position = navigation_car.transform.position;
            Instantiate(explosion, new Vector3(contactPoint.x, 10f, contactPoint.z), Quaternion.identity);

            //navigation_car.transform.position = navigation_car.transform.position;
            yield return new WaitForSeconds(duration);
            if (spam_car_player)
            {


                StartCoroutine(delay_spamcar(0.2f));
            }
            //Spamplayer.Invoke();
            // control_Rb();
            //gameover = false;

        }

    }

    private IEnumerator delay_spamcar(float a)
    {


        Debug.Log("spam mấy lần");
        canIncreaseSpeed = false;
        Spamplayer.Invoke();
        control_Rb();
        gameover = false;
        spam_car_player = false;
        yield return new WaitForSeconds(a);

        canIncreaseSpeed = true;
        spam_car_player = true;

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

        BlinkController.runblink_gameobj(navigation_car);


        StartCoroutine(DisableSpeedIncrease(1.5f, contactPoint));
    }
    private IEnumerator DisableSpeedIncrease(float duration, Vector3 contactPoint)
    {
        if (speed <= 300)
        {
            cars_soundScript.onCrashSound();
            canIncreaseSpeed = false;
            yield return new WaitForSeconds(duration);
            canIncreaseSpeed = true;
        }
        else
        {
            cars_soundScript.stoptRunCarSound();
            cars_soundScript.onbigcrashSound();
            gameover = true;
            navigation_car.transform.SetParent(null);

            //// Giữ nguyên vị trí hiện tại của A
            //navigation_car.transform.position = navigation_car.transform.position;
            Instantiate(explosion, new Vector3(contactPoint.x, 10f, contactPoint.z), Quaternion.identity);

            //navigation_car.transform.position = navigation_car.transform.position;
            yield return new WaitForSeconds(duration);
            event_gameOver.Invoke();
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

        position.x = Mathf.Clamp(position.x, minX, maxX);

        navigation_car.transform.position = position;
        if (position.x <= minX)
        {
            if (turnleft)
            {
                StartCoroutine(DisableSpeedIncreaseFence(0.1f));
                cars_soundScript.onbarrierHitSound();

            }
            turnleft = false;

        }
        else if (position.x >= maxX)
        {
            if (turnright)
            {
                StartCoroutine(DisableSpeedIncreaseFence(0.1f));
                cars_soundScript.onbarrierHitSound();
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

        if (Input.GetKey(KeyCode.K) || isAccelerating && canIncreaseSpeed)
        {

            accelerate_Inactive = false;
            turnSignalScript.Acceleration_car();
            cars_soundScript.startAcceleratedSound();
            targetSpeed = maxSpeed;
            speedRunTime = accelerate;

        }
        else
        {
            accelerate_Inactive = true;
            if (!canIncreaseSpeed)
            {
                targetSpeed = minSpeed - 30;

                speedRunTime = 10f;
            }
            else
            {
                targetSpeed = minSpeed;
                speedRunTime = deceleration;
            }
            if (deceleration_Inactive)
            {
                turnSignalScript.Inactive_Deceleration_Acceleration_car_car();
                cars_soundScript.stopAcceleratedSound();
            }
        }
        if (Input.GetKey(KeyCode.J) || isDecelerating)
        {
            deceleration_Inactive = false;
            turnSignalScript.Deceleration_car();
            cars_soundScript.startDecelerationSound();
            targetSpeed = minSpeed;
            speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * 5f);
            if (!hasCheckedBrake)
            {
                hasCheckedBrake = true; 
                if (speed >= 250)
                {
                    brake_suddenlyScript.brake();
                    cars_soundScript.onDriftSound2();
                }
            }


        }
        else
        {
            deceleration_Inactive = true;
            if (gameover)
            {
                speed = Mathf.Lerp(speed, 0f, Time.deltaTime * 0.15f);
            }
            else
            {
                speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * speedRunTime);
            }
            if (accelerate_Inactive)
            {
                turnSignalScript.Inactive_Deceleration_Acceleration_car_car();
                cars_soundScript.stopDecelerationSound();
            }
        }

    }


    public void on_flash()
    {
        turnSignalScript.on_light();
    }
    public void off_flash()
    {
        turnSignalScript.off_light();
    }
    public void on_whistle()
    {
        cars_soundScript.startWhistleSound();
    }
    public void off_whistle()
    {
        cars_soundScript.stopWhistleSound();
    }
    public void on_runcarSound()
    {
        cars_soundScript.startRunCarSound();
    }
    public void off_runcarSound()
    {
        cars_soundScript.stoptRunCarSound();
    }
    public void on_overtakeSound()
    {
        cars_soundScript.onovertakeSound();
    }


    public void control_Rb()
    {
        player_rb = GetComponent<Rigidbody>();
        GameObject B = GameObject.Find("oto");

        targetSpeed = minSpeed;
        if (B != null)
        {

            Transform A = B.transform.GetChild(0); 
            navigation_car = B.transform.GetChild(0).gameObject;
            if (A != null)
            {
                rb = A.GetComponent<Rigidbody>();
                turnSignalScript = navigation_car.GetComponent<TurnSignal>();
                brake_suddenlyScript = navigation_car.GetComponent<brake_suddenly>();
                control_rollingwheelScript = navigation_car.GetComponent<control_rollingwheel>();
                cars_soundScript = navigation_car.GetComponent<Cars_sound>();
                cars_soundScript.startRunCarSound();
                event_startgame.Invoke();
            }
        }
    }


}
