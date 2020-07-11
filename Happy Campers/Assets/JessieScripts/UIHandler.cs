﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Image EmptySprite;
    [SerializeField] private Image Highlighter;
    [SerializeField] private Image[] UIIcons;
    private Inventory inventory;
    

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnEnable()
    {
        inventory.changeIndex += RefreshUI;
    }

    private void OnDisable()
    {
        inventory.changeIndex -= RefreshUI;
    }

    void RefreshUI(int num)
    {
        for(int i = 0; i < UIIcons.Length; ++i)
        {
            if (i > inventory.GetLength() - 1)
            {
                UIIcons[i].sprite = EmptySprite.sprite;
                print("clearing sprite");
                continue;
            }

            Sprite spr = inventory.GetItem(i).GetComponent<SpriteRenderer>().sprite;

            if(spr == null)
            {
                UIIcons[i].sprite = EmptySprite.sprite;
                print("sprite missing");
                continue;
            }

            UIIcons[i].sprite = spr;
        }

        Highlighter.rectTransform.position = UIIcons[inventory.GetCurrentIndex()].rectTransform.position;

    }
}
