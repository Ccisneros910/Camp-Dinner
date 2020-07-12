using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    GoalManager points;

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bush" && Input.GetKeyDown(KeyCode.Space))
        {
            col.gameObject.GetComponent<BushManager>().take_fruit();
            Debug.Log("Bush");
        }
        else if (col.gameObject.tag == "Goal" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Items dropped off");
            col.gameObject.GetComponent<GoalManager>().congrats();
            points.point1Up();
        }
    }
}
