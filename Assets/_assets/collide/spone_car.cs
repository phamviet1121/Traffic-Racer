using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spone_car : MonoBehaviour
{
    public GameObject[] list_cars;
    public GameObject[] list_cars_1_1;
    public GameObject[] location;
    public GameObject[] location_1_1;
    public int regime;

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
            int randomIndex = Random.Range(0, cars.Length); 
            randomCars[i] = cars[randomIndex]; 
        }
        return randomCars;
    }

    public void SpawnCars_1_1(int quantity_cars)
    {
        int randomSpamQuantityCar = Random.Range(0, 3);
        int randomSpamQuantityCar_1_1 = Random.Range(0, 3);


        GameObject[] randomCars = GetRandomCars(list_cars, randomSpamQuantityCar);
        for (int i = 0; i < randomCars.Length; i++)
        {
            int randomIndex_location = Random.Range(0, location.Length);
            Instantiate(randomCars[i], location[randomIndex_location].transform.position, randomCars[i].transform.rotation);
        }
        GameObject[] randomCars_1_1 = GetRandomCars(list_cars_1_1, randomSpamQuantityCar_1_1);
        for (int i = 0; i < randomCars_1_1.Length; i++)
        {
            int randomIndex_location = Random.Range(0, location_1_1.Length);
            Instantiate(randomCars_1_1[i], location_1_1[randomIndex_location].transform.position, randomCars_1_1[i].transform.rotation);
        }
    }



}

