using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Fruit point trackers
    int goal1, goal2, goal3;

    [SerializeField]
    GoalManager points;

    [SerializeField]
    Inventory inv;

    void Awake()
    {
        goal1 = 3;
        goal2 = 3;
        goal3 = 3;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (points.point1() == goal1 && points.point2() == goal2 && points.point3() == goal3)
        {

        }
        */
    }
}
