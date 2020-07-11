using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{
    [SerializeField] private Inventory myInventory;
    [SerializeField] private int index;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down);

            if (ray)
            {
                print("Hit something: " + ray.collider.gameObject.name);
                GameObject itemToPickUp = ray.collider.GetComponent<ICollectible>().PickUp();
                myInventory.AddToInventory(itemToPickUp);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseItem();
        }else if (Input.GetKeyDown(KeyCode.M))
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        myInventory.DropItem();
    }

    public void UseItem()
    {
        if (myInventory.GetCurrentIndex() < 0 || myInventory.GetCurrentIndex() > myInventory.GetLength() - 1)
        {
            print("Out of bounds");
            return;
        }
        IUsable usable = myInventory.GetItem().GetComponent<IUsable>();
        if (usable != null)
        {
            usable.Use();
        }
        else
        {
            print("Item is unusable");
        }
    }
}
