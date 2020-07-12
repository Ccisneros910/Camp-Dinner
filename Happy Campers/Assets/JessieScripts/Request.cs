using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request
{
    public enum FoodTypes
    {
        Marshmellon, 
        Bananadog,
        Smorange
    }

    FoodTypes[] foods;

    public Request()
    {
        foods = new FoodTypes[3];
        GenerateNewRequest();
    }

    public void GenerateNewRequest()
    {
        foods[0] = (FoodTypes)Random.Range(0, 3);
        foods[1] = (FoodTypes)Random.Range(0, 3);
        foods[2] = (FoodTypes)Random.Range(0, 3);
    }

    public FoodTypes GetFood(int i)
    {
        if(i > foods.Length)
        {
            Debug.Log("out of bounds");
        }
        return foods[i];
    }
}
