using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnusableItem : MonoBehaviour, ICollectible
{
    [SerializeField] private string name;
    public GameObject PickUp()
    {
        return gameObject;
    }

}
