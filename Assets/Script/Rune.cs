using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float Delay = 1f;
    public float start = 1f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - Delay > start)
        {
            Delay = Time.time;
            spriteRenderer.color = new Color(123,123,123);
        }
        else
        {
            spriteRenderer.color = new Color(255, 255, 255);
        }

      
    }
}
