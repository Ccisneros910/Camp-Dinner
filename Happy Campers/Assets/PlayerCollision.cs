using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GoalManager points;
    [SerializeField] GameManager pointTracker;

    [SerializeField] Inventory inv;

    private void OnTriggerStay2D(Collider2D col)
    {
        // col.gameObject.GetComponent<BushManager>().check_if_ready() == true
        if (col.gameObject.tag == "S'Morange" && Input.GetKeyDown(KeyCode.Space))
        {
            inv.AddToInventory(col.gameObject);
            col.gameObject.GetComponent<BushManager>().take_fruit();
            Debug.Log("S'Morange");
        }
        else if (col.gameObject.tag == "Bananadog" && Input.GetKeyDown(KeyCode.Space))
        {
            inv.AddToInventory(col.gameObject);
            col.gameObject.GetComponent<BushManager>().take_fruit();
            Debug.Log("Bananadog");
        }
        else if (col.gameObject.tag == "Marshmelons" && Input.GetKeyDown(KeyCode.Space))
        {
            inv.AddToInventory(col.gameObject);
            col.gameObject.GetComponent<BushManager>().take_fruit();
            Debug.Log("Marshmelons");
        }
        else if (col.gameObject.tag == "Goal" && Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("Items dropped off");
            col.gameObject.GetComponent<GoalManager>().congrats();
            pointTracker.addItems(inv);
        }
    }
}
