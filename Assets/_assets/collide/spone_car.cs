using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spone_car : MonoBehaviour
{
    public GameObject[] list_cars;
    public GameObject[] location;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    // Hàm spawn xe
    public void SpawnCars(int quantity_cars)
    {
        GameObject[] randomCars = GetRandomCars(list_cars, quantity_cars);
       for(int i=0; i<randomCars.Length; i++)
        {
            int randomIndex_location = Random.Range(0, location.Length);
            Instantiate(randomCars[i], location[randomIndex_location].transform.position, randomCars[i].transform.rotation);
        }    
    }

    GameObject[] GetRandomCars(GameObject[] cars, int count)
    {
        GameObject[] randomCars = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, cars.Length); // Lấy chỉ số ngẫu nhiên
            randomCars[i] = cars[randomIndex]; // Thêm phần tử vào mảng kết quả
        }
        return randomCars;
    }
}

