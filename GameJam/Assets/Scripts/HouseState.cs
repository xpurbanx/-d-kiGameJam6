using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseState : MonoBehaviour
{

    public int level;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        ItemRequired.Instance.printLists();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
