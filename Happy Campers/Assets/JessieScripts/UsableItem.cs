using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour, ICollectible, IUsable, IDroppable
{
    [SerializeField] private string name;
    [SerializeField] private Sprite mySprite;

    public GameObject PickUp()
    {
        return gameObject;
    }

    public void Use()
    {
        print("I have a " + name);
    }

    public Sprite GetSprite()
    {
        return mySprite;
    }

    public void Drop()
    {
        //print("Omg homegurl dropped: " + name);
    }

    public string GetName()
    {
        return name;
    }
}
