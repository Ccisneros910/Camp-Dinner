using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public ParticleSystem p;

    public void congrats()
    {
        p.Play();
    }
}
