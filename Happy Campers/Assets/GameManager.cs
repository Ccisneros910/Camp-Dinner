using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Fruit point trackers
    int fruit1, fruit2, fruit3;
    int goal1, goal2, goal3;

    [SerializeField]
    GoalManager points;

    [SerializeField]
    Inventory inv;

    void Awake()
    {
        fruit1 = 0;
        fruit2 = 0;
        fruit3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (fruit1 == 2 && fruit2 == 2 && fruit3 == 2)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void point1Up() { fruit1++; }
    public void point2Up() { fruit2++; }
    public void point3Up() { fruit3++; }

    public void addItems(Inventory inv)
    {
        while(inv.GetLength() != 0)
        {
            string obj = inv.GetItem(0).tag;
            increase_score(obj);
            inv.DropItem(0);
        }

        Debug.Log(fruit1);
        Debug.Log(fruit2);
        Debug.Log(fruit3);
        inv.ClearItems();
    }

    void increase_score(string s)
    {
        if(s == "S'Morange") { fruit1++; }
        else if (s == "Bananadog") { fruit2++; }
        else if (s == "Marshmelons") { fruit3++; }
    }
}
