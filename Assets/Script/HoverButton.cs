using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{

    public Button button;
    public Color WantedColor;
    private Color originalcolor;
    private ColorBlock cb;

    // Start is called before the first frame update
    void Start()
    {

        cb = button.colors;
        originalcolor = cb.selectedColor;

    }

   public void changeWhenColor()
    {
        cb.selectedColor = WantedColor;
        button.colors = cb;
    }

    public void changeWheLeaves()
    {
        cb.selectedColor = originalcolor;
        button.colors = cb;
    }

}
