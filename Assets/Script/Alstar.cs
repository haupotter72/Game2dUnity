using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alstar : MonoBehaviour
{

    public List<SpriteRenderer> sprites;
    public float leftSpeed;

    private Color curColor;
    private Color targerColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            targerColor = new Color(1, 1, 1, 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            targerColor = new Color(1, 1, 1, 0);
    }


    // Update is called once per frame
    void Update()
    {
        curColor = Color.Lerp(curColor, targerColor, leftSpeed * Time.fixedDeltaTime );
        foreach(var v in sprites)
        {
            v.color = curColor;
        }
    }
}
