using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HouseState : MonoBehaviour
{
    private List<GameObject> itemType;
    [HideInInspector]
    public List<GameObject> itemsToLvl = new List<GameObject>();
    public int level = 1;
    private int score = 1;

    void Start()
    {
        level = 1;
        RequiredItem(level);
    }

    void Update()
    {
        if (itemsToLvl.FirstOrDefault() == null)
        {
            LevelUp();
            RequiredItem(level);
        }
    }

    void LevelUp()
    {
        level = level + 1;
    }

    void RequiredItem(int level)
    {
        itemType = GameObject.Find("Item Manager").GetComponent<ItemRequired>().allItems;

        int randomItemType = Random.Range(0, 12);
        itemsToLvl.Add(itemType[randomItemType]);

        foreach (GameObject item in itemsToLvl)
        {
            Debug.Log(item);
        }
    }
}
