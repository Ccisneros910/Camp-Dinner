using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Fruit point trackers
    int point1, point2, point3;
    int goal1, goal2, goal3;

    void Awake()
    {
        point1 = 0;
        point2 = 0;
        point3 = 0;
        goal1 = 3;
        goal2 = 3;
        goal3 = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (point1 == goal1 && point2 == goal2 && point3 == goal3)
        {

        }
    }
}
