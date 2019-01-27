using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private List<GameObject> itemsNeeded;
    private List<GameObject> lastNeeded;
    [SerializeField]
    private List<SpriteRenderer> spriteSpaces;

    bool alreadySet = false;
    
    
    // Start is called before the first frame update
    void Start()
    {

        if (tag == "Player 1") itemsNeeded = GameObject.FindGameObjectWithTag("House1").GetComponent<HouseState>().itemsToLvl;
        if (tag == "Player 2") itemsNeeded = GameObject.FindGameObjectWithTag("House2").GetComponent<HouseState>().itemsToLvl;
        lastNeeded = itemsNeeded;

    }

    // Update is called once per frame
    void Update()
    {

        setSprites();
        if (itemsNeeded != lastNeeded)
        {
            Debug.Log("LIST CHANGED");
            lastNeeded = itemsNeeded;
            //setSprites();


        }


    }
    void setSprites()
    {
        int i = 0;
        for(; i < itemsNeeded.Count; i++)
        {
            spriteSpaces[i].sprite = itemsNeeded[i].GetComponent<SpriteRenderer>().sprite;
        }
        for(;i < 5; i++)
        {
            spriteSpaces[i].sprite = null;
        }

        
    }
}
