using UnityEngine;

public class ItemsManagement : MonoBehaviour
{
    public GameObject[] itemType = new GameObject[11];

    private Vector2 lastPosition = new Vector3(0, 0, 0);
    private float mapX;
    private float mapY;

    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        mapX = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.x;
        mapY = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.y;
        int randomItemType;

        for (int i = 0; i < 16; i++)
        {
            randomItemType = Random.Range(0, 11);
            float x = Random.Range(-mapX/2, mapX/2);
            float y = Random.Range(-mapY/2, mapY/2);
            GameObject item = Instantiate(itemType[randomItemType]);

            item.transform.position = new Vector2(x, y);
        }
    }
}