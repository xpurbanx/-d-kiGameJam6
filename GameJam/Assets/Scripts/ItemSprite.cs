using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprite : MonoBehaviour
{

    public Sprite shadow;
    public Sprite noShadow;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
