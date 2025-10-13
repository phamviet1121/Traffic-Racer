using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class spone_car : MonoBehaviour
{
    public GameObject[] list_cars;
    public GameObject[] list_cars_1_1;
    public GameObject[] location;
    public GameObject[] location_1_1;
    public GameObject[] carAI;
    public GameObject[] carAI_2;
    public int regime;

    public void randomTurnRate(GameObject carAI)
    {
        MOVER_AI moverAI = carAI.GetComponent<MOVER_AI>();
        if (Random.value <= 0.1f)  // 10% xác suất (Random.value trả về số từ 0.0 đến 1.0)
        {
            moverAI.turningProbability = true;
        }
        else
        {
            moverAI.turningProbability = false;
        }
    }
    // Hàm spawn xe
    public void SpawnCars(int quantity_cars)
    {
        GameObject[] randomCars = GetRandomCars(list_cars, quantity_cars);
        GameObject[] randomLocations = GetRandomLocation(location, randomCars.Length);

        for (int i = 0; i < randomCars.Length; i++)
        {
            // int randomIndex_location = Random.Range(0, location.Length);
            // Instantiate(randomCars[i], location[randomIndex_location].transform.position, randomCars[i].transform.rotation);
            GameObject newCar = Instantiate(randomCars[i], randomLocations[i].transform.position, randomCars[i].transform.rotation);
            randomTurnRate(newCar);
        }
    }

    GameObject[] GetRandomCars(GameObject[] cars, int count)
    {
        GameObject[] randomCars = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, cars.Length);
            randomCars[i] = cars[randomIndex];
        }
        return randomCars;
    }

    GameObject[] GetRandomLocation(GameObject[] location, int indexCars)
    {

        // Copy mảng gốc để tránh làm thay đổi mảng ban đầu
        List<GameObject> shuffled = new List<GameObject>(location);

        // Fisher-Yates Shuffle
        for (int i = shuffled.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = shuffled[i];
            shuffled[i] = shuffled[j];
            shuffled[j] = temp;
        }

        // Lấy số lượng bằng số lượng indexCars
        int count = Mathf.Min(indexCars, shuffled.Count);
        GameObject[] randomLocation = shuffled.GetRange(0, count).ToArray();
        return randomLocation;
    }



    public void SpawnCars_1_1(int quantity_cars)
    {
        int randomSpamQuantityCar = Random.Range(0, 3);
        int randomSpamQuantityCar_1_1 = Random.Range(0, 3);
        GameObject[] randomLocations = GetRandomLocation(location, randomSpamQuantityCar);
        GameObject[] randomLocations_1_1 = GetRandomLocation(location_1_1, randomSpamQuantityCar_1_1);


        GameObject[] randomCars = GetRandomCars(list_cars, randomSpamQuantityCar);
        for (int i = 0; i < randomCars.Length; i++)
        {
            //int randomIndex_location = Random.Range(0, location.Length);
            //Instantiate(randomCars[i], location[randomIndex_location].transform.position, randomCars[i].transform.rotation);
            GameObject newCar = Instantiate(randomCars[i], randomLocations[i].transform.position, randomCars[i].transform.rotation);
            randomTurnRate(newCar);

        }
        GameObject[] randomCars_1_1 = GetRandomCars(list_cars_1_1, randomSpamQuantityCar_1_1);
        for (int i = 0; i < randomCars_1_1.Length; i++)
        {
            //int randomIndex_location = Random.Range(0, location_1_1.Length);
            // Instantiate(randomCars_1_1[i], location_1_1[randomIndex_location].transform.position, randomCars_1_1[i].transform.rotation);
            GameObject newCar = Instantiate(randomCars_1_1[i], randomLocations_1_1[i].transform.position, randomCars_1_1[i].transform.rotation);
            randomTurnRate(newCar);
        }
    }



}

