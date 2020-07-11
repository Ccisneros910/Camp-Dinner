using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushManager : MonoBehaviour
{
    //Berry sprites
    public GameObject[] berries;
    private bool fruitReady;
    private float timer;

    void awake()
    {
        fruitReady = true;
        timer = 5f;
    }

    public void take_berries()
    {
        fruitReady = false;
        foreach(GameObject x in berries)
        {
            x.GetComponent<Transform>().localScale = new Vector3(0f, 0f, 0f);
        }
    }
}
