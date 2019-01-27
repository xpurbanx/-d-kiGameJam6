﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HouseState : MonoBehaviour
{
    private List<GameObject> itemType;
    [HideInInspector]
    public List<GameObject> itemsToLvl = new List<GameObject>();
    private int level = 1;
    private int score = 1;

    void Start()
    {
        level = 1;
        RequiredItemList(level);
    }

    void Update()
    {
        if (itemsToLvl.FirstOrDefault() == null)
        {
            LevelUp();
            RequiredItemList(level);
        }
    }

    void LevelUp()
    {
        level = level + 1;
    }

    void RequiredItemList(int level)
    {
        itemType = GameObject.Find("Item Manager").GetComponent<ItemRequired>().allItems;

        if (level < 6)
        {
            for (int i = 0; i < 3; i++)
            {
                int randomItemType = Random.Range(0, 12);
                itemsToLvl.Add(itemType[randomItemType]);
            }
        }

        else if (level < 11)
        {
            for (int i = 0; i < 5; i++)
            {
                int randomItemType = Random.Range(0, 12);
                itemsToLvl.Add(itemType[randomItemType]);
            }
        }

        else if (level < 16)
        {
            for (int i = 0; i < 7; i++)
            {
                int randomItemType = Random.Range(0, 12);
                itemsToLvl.Add(itemType[randomItemType]);
            }
        }

        foreach (GameObject item in itemsToLvl)
        {
            Debug.Log(item);
        }
    }
}
