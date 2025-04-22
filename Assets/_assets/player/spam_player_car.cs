using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class spam_player_car : MonoBehaviour
{
    public GameObject player_car;  // Đối tượng bạn muốn tạo
    public Transform folder_car;  // Thư mục (hoặc đối tượng cha) mà bạn muốn tạo GameObject B bên trong
    public list_cars list_cars;
    public UnityEvent UnityEvent_loadCar;
    void Awake()
    {
        Debug.Log("spam chay");
        UnityEvent_loadCar.Invoke();
    }


    public void Spam_player()
    {
        // Tạo GameObject B và gán vào vị trí (0, 0, 0) bên trong folderA
        GameObject newB = Instantiate(player_car, folder_car.position, Quaternion.identity);

        // Đặt folderA là cha của newB
        newB.transform.SetParent(folder_car);

        // Đảm bảo rằng vị trí của newB là (0, 0, 0) trong folderA
        newB.transform.localPosition = Vector3.zero;
        newB.transform.SetSiblingIndex(0);
    }

    public void loadplayer()
    {
        player_car = list_cars.player;
    }
}
