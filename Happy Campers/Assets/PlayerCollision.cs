using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bush" && Input.GetKeyDown(KeyCode.Space))
        {
            col.gameObject.GetComponent<BushManager>().take_berries();
            Debug.Log("Bush");

        }
    }
}
