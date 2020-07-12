using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandlerRequests : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image[] UIIcons;
    private Inventory inventory;


    public void RefreshUI(int num)
    {
        for (int i = 0; i < UIIcons.Length; ++i)
        {
            UIIcons[i].sprite = sprites[i];
        }

    }

    public void ConfigureRequest(Request req)
    {
        for(int i = 0; i < 3; ++i)
        {
            print("blah" + (int)req.GetFood(i));
            UIIcons[i].sprite = sprites[(int)req.GetFood(i)];
        }
    }
}
