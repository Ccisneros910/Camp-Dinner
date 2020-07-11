using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int heldItems;

    // Start is called before the first frame update
    void Start()
    {
        heldItems = 0;
    }

    public void addItem()
    {
        if (heldItems < 3) {
            heldItems++;
            Debug.Log(heldItems);
        }
    }
}
