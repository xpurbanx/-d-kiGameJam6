using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseUpgrade : MonoBehaviour
{
    public List<GameObject> levels;
    public int level_check;
    public int currentLevel;
   

    void Start()
    {

        level_check = GetComponent<HouseState>().level;
        foreach (var level in levels)
            level.SetActive(false);
    }

    void UpgradeHouse()
    {
        for (int i = 0; i < levels.Capacity; i++)
        {
            if (level_check == i+1)
            {
                if (i == 8)
                    levels[1].SetActive(false);

                levels[i].SetActive(true);

                

                level_check++;
                return;
            }
               
                    
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = GetComponent<HouseState>().level;

        if (level_check < currentLevel)
            UpgradeHouse();


    }
}
