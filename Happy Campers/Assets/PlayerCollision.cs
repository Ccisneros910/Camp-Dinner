using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Inventory myInventory;


    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bush" && Input.GetKeyDown(KeyCode.Space))
        {
            col.gameObject.GetComponent<BushManager>().take_berries();
            Debug.Log("Bush");
        }else if(col.gameObject.tag == "Pile" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pile");
            //col.gameObject.GetComponent<PileManager>().CheckItems(myInventory);
            col.gameObject.GetComponent<PileManager>().PurgeItems(myInventory);
        }
    }
}
