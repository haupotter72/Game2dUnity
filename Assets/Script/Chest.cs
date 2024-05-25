using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite img;

    public GameObject stoneMagic;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.name == "Player")
        {
            spriteRenderer.sprite = img;
            Instantiate(stoneMagic, transform.position, Quaternion.identity);
        }
    }
}
