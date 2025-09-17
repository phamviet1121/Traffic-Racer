using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Thư viện để làm việc với UI
public class PanelInputHandler : MonoBehaviour
{
    public RectTransform panel; // Tham chiếu đến panel được gán từ Inspector

    private bool left = false; // Biến bool xác định nếu người dùng chạm hoặc di chuyển về bên trái
    private bool right = false; // Biến bool xác định nếu người dùng chạm hoặc di chuyển về bên phải

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
            HandleTouchInput(); // Gọi hàm xử lý input
            //mover.input_left = left;
            //mover.input_right = right;
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

    void HandleTouchInput() // Hàm gộp toàn bộ xử lý input
    {
        if (Input.touchCount > 0) // Kiểm tra nếu có ít nhất một ngón tay chạm vào màn hình
        {
            Touch touch = Input.GetTouch(0); // Lấy thông tin của ngón tay đầu tiên
            Vector2 touchPosition = touch.position; // Lấy vị trí của ngón tay trên màn hình

            // Kiểm tra xem vị trí chạm có nằm trong panel hay không
            if (RectTransformUtility.RectangleContainsScreenPoint(panel, touchPosition))
            {
                float panelCenterX = panel.position.x; // Lấy tọa độ x của tâm panel

                // Xác định vị trí ngón tay so với panel
                if (touchPosition.x < panelCenterX - 20f)
                {
                    left = true;
                    right = false;
                }
                else if (touchPosition.x > panelCenterX + 20f)
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
                left = false; // Nếu ngón tay không nằm trong panel
                right = false;
            }
        }
        else // Nếu không có ngón tay nào chạm vào màn hình
        {
            left = false;
            right = false;
        }

        //Debug.Log($"Left: {left}, Right: {right}"); // In giá trị left và right ra console để kiểm tra
    }

    public (bool, bool) GetInputValue() // Hàm public để lấy giá trị left và right
    {
        return (left, right); // Trả về trạng thái của left và right
    }
}
