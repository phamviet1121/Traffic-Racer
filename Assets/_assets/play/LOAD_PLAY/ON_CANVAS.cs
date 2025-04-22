using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_CANVAS : MonoBehaviour
{
    public GameObject Canvas;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void oncanvas()
    {
        Canvas.SetActive(true);
    }

    public void offcanvas()
    {
        Canvas.SetActive(false);
    }

    public void on_player()
    {
        Time.timeScale = 1;
    }
    public void off_player()
    {
        Time.timeScale = 0;
    }
}
