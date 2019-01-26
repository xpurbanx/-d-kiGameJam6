using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemRequired : MonoBehaviour
{
    public static ItemRequired Instance;

    public List<List<string>> itemsForLevel;
    public List<GameObject> allItems;
    private List<GameObject> shuffledList = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> itemsSide1 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> itemsSide2 = new List<GameObject>();


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        shuffledList = allItems.OrderBy(x => Random.value).ToList();
        splitList();
        //printLists();

    } 
    private void splitList()
    {
        for (int i = 0; i < shuffledList.Count; i++) // as long as allItems.count % 2 == 0
        {
            itemsSide1.Add(shuffledList[i]);
            i++;
            itemsSide2.Add(shuffledList[i]);
        }

    }
    public void printLists()
    {
        Debug.Log("LIST 1");
        foreach (GameObject gameObject in itemsSide1)
        {
            Debug.Log(gameObject.name);
        }
        Debug.Log("LIST 2");
        foreach (GameObject gameObject in itemsSide2)
        {
            Debug.Log(gameObject.name);
        }
    }



}
