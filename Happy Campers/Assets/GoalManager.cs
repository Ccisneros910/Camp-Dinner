using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public ParticleSystem p;
    private int fruit1, fruit2, fruit3;

    [SerializeField]
    Inventory inv;
    // Start with collected material totals at 0
    void Awake()
    {
        fruit1 = 0;
        fruit2 = 0;
        fruit3 = 0;
    }

    // Getters
    public int point1() { return fruit1; }
    public int point2() { return fruit2; }
    public int point3() { return fruit3; }

    // Increase score
    public void point1Up() { fruit1++; }
    public void point2Up() { fruit2++; }
    public void point3Up() { fruit3++; }

    void increase_points()
    {

    }

    // Activate particle system
    public void congrats()
    {
        p.Play();
    }
}
