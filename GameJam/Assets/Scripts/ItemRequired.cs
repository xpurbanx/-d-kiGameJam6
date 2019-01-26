using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemRequired : MonoBehaviour
{
    public static ItemRequired Instance;

    public List<List<string>> itemsForLevel;
    public List<GameObject> allItems;
    public List<GameObject> usableItems;
    [HideInInspector]
    public List<GameObject> itemsSide1 = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> itemsSide2 = new List<GameObject>();
    public int numberOfItems;

    private List<GameObject> shuffledList = new List<GameObject>();
    private Vector2 lastPosition = new Vector3(0, 0, 0);
    private float mapX;
    private float mapY;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        shuffledList = allItems.OrderBy(x => Random.value).ToList();
        SplitList();
        SpawnItems();
        //printLists();

    }

    private void SplitList()
    {
        for (int i = 0; i < shuffledList.Count; i++) // as long as allItems.count % 2 == 0
        {
            itemsSide1.Add(shuffledList[i]);
            i++;
            itemsSide2.Add(shuffledList[i]);
        }

    }

    public void PrintLists()
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

    void SpawnItems()
    {
        mapX = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.x;
        mapY = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.y;
        int randomItemType;

        for (int i = 0; i < numberOfItems / 2; i++)
        {
            randomItemType = Random.Range(0, 5);

            bool looping = true;
            while (looping == true)
            {
                float x = Random.Range(-mapX / 2 +2.7f, -2.7f);
                float y = Random.Range(-mapY / 2 + 6f, mapY / 2);

                // CZĘŚĆ MICHAŁA: DETEKCJA KOLIZJI PRZY SPAWNIE PRZEDMIOTU

                Vector3 spawnPos = new Vector3(x, y);
                float radius = 1f;
                //if(Physics2D.Distance(spawnPos, ))
                if (Physics2D.OverlapCircle(spawnPos, radius))
                {
                    // jeżeli kolizja blokuje spawn
                    looping = true;
                    //Debug.Log("Musiano powtórzyć losowanie");
                }
                else
                {
                    looping = false;
                    //Debug.Log("Wyspawnuj jeden item | "+x+", "+y);
                    GameObject item = Instantiate(itemsSide1[randomItemType]);
                    item.transform.position = new Vector2(x, y);
                }
            }
        }

        for (int i = 0; i < numberOfItems / 2; i++)
        {
            randomItemType = Random.Range(0, 5);

            bool looping = true;
            while (looping == true)
            {
                float x = Random.Range(2.7f, mapX / 2 - 2.7f);
                float y = Random.Range(-mapY / 2 + 6f, mapY / 2);

                // CZĘŚĆ MICHAŁA: DETEKCJA KOLIZJI PRZY SPAWNIE PRZEDMIOTU

                Vector3 spawnPos = new Vector3(x, y);
                float radius = 1f;
                //if(Physics2D.Distance(spawnPos, ))
                if (Physics2D.OverlapCircle(spawnPos, radius))
                {
                    // jeżeli kolizja blokuje spawn
                    looping = true;
                    //Debug.Log("Musiano powtórzyć losowanie");
                }
                else
                {
                    looping = false;
                    //Debug.Log("Wyspawnuj jeden item | "+x+", "+y);
                    GameObject item = Instantiate(itemsSide2[randomItemType]);
                    item.transform.position = new Vector2(x, y);
                }
            }
        }
    }
}
