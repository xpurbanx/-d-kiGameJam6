﻿using UnityEngine;

public class ItemsManagement : MonoBehaviour
{
    public GameObject[] itemType;
    public static bool isPicked;

    private float mapX;
    private float mapY;

    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        int randomItemType;
        for (int i = 0; i < 16; i++)
        {
            randomItemType = Random.Range(0, 3);
            float x = Random.Range(-7.0f, 7.0f);
            float y = Random.Range(-7.0f, 7.0f);
            GameObject item = Instantiate(itemType[randomItemType]);
            item.transform.position = new Vector2(x, y);
        }
    }
}