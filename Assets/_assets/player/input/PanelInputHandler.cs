using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Thư viện để làm việc với UI
public class PanelInputHandler : MonoBehaviour
{
    public RectTransform panel; 

    private bool left = false; 
    private bool right = false; 

    public mover mover;
    public bool on_setting_inputmoush = false;
    public void Start()
    {
        //on_setting_inputmoush = false;
    }
    void Update()
    {
        if (on_setting_inputmoush)
        {
            HandleTouchInput();
            if (left)
            {
                mover.input_getkey_left();
            }
            else
            {
                mover.getkeyup_left();
            }
            if (right)
            {
                mover.input_getkey_right();
            }
            else
            {
                mover.getkeyup_right();
            }
            
        }


    }

    void HandleTouchInput() 
    {
        left = false;
        right = false;

        if (Input.touchCount == 0) return; 

        Touch? controllingFinger = null; 

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (RectTransformUtility.RectangleContainsScreenPoint(panel, touch.position))
            {
                controllingFinger = touch;
                break; 
            }
        }

        if (controllingFinger.HasValue)
        {
            Vector2 pos = controllingFinger.Value.position;
            float centerX = panel.position.x;

            if (pos.x < centerX - 20f)
            {
                left = true;
                right = false;
            }
            else if (pos.x > centerX + 20f)
            {
                left = false;
                right = true;
            }
            else
            {
                left = false;
                right = false; 
            }
        }
        else
        {
            left = false;
            right = false;
        }

        //if (Input.touchCount > 0) // Kiểm tra nếu có ít nhất một ngón tay chạm vào màn hình
        //{
        //    Touch touch = Input.GetTouch(0); // Lấy thông tin của ngón tay đầu tiên
        //    Vector2 touchPosition = touch.position; // Lấy vị trí của ngón tay trên màn hình

        //    // Kiểm tra xem vị trí chạm có nằm trong panel hay không
        //    if (RectTransformUtility.RectangleContainsScreenPoint(panel, touchPosition))
        //    {
        //        float panelCenterX = panel.position.x; // Lấy tọa độ x của tâm panel

        //        // Xác định vị trí ngón tay so với panel
        //        if (touchPosition.x < panelCenterX - 20f)
        //        {
        //            left = true;
        //            right = false;
        //        }
        //        else if (touchPosition.x > panelCenterX + 20f)
        //        {
        //            left = false;
        //            right = true;
        //        }
        //        else
        //        {
        //            left = false;
        //            right = false;
        //        }
        //    }
        //    else
        //    {
        //        left = false; // Nếu ngón tay không nằm trong panel
        //        right = false;
        //    }
        //}
        //else // Nếu không có ngón tay nào chạm vào màn hình
        //{
        //    left = false;
        //    right = false;
        //}

        //Debug.Log($"Left: {left}, Right: {right}"); // In giá trị left và right ra console để kiểm tra
    }

    public (bool, bool) GetInputValue() 
    {
        return (left, right); 
    }
}
