using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class destroy_txt : MonoBehaviour
{
    private TextMeshPro tmp;  // Tham chiếu đến TextMeshPro
    public float fadeDuration = 1.5f;
    public float sizeIncrease = 50f;
    private float startFontSize;
    void Start()
    {
        // Lấy thành phần TextMeshPro trên GameObject này
        tmp = GetComponent<TextMeshPro>();

        if (tmp != null)
        {
            startFontSize = tmp.fontSize;
            StartCoroutine(FadeOut()); // Bắt đầu hiệu ứng mờ dần
        }
    }


    IEnumerator FadeOut()
    {
        Color32 color = tmp.color; // Lấy màu hiện tại của text
        float startAlpha = color.a; // Lấy giá trị alpha ban đầu (0 - 255)
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;

            // Giảm alpha dần
            float newAlpha = Mathf.Lerp(startAlpha, 0, t);
            tmp.color = new Color(color.r, color.g, color.b, newAlpha);

            // Tăng font size dần
            tmp.fontSize = Mathf.Lerp(startFontSize, startFontSize + sizeIncrease, t);

            yield return null; // Đợi frame tiếp theo
        }

        tmp.color = new Color32(color.r, color.g, color.b, 0); // Đảm bảo alpha = 0
        tmp.fontSize = startFontSize + sizeIncrease;
    }








    public void Destroy_Txt_plus_point()
    {
        Destroy(gameObject);

    }


}
