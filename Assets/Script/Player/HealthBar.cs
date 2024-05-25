using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slidebar;
    public Color low;
    public Color high;
    public Vector3 Offset;


    public void setHealth(float health, float maxhealth, GameObject gameObject)
    {
        if(gameObject.tag != "Player")
        {
            slidebar.gameObject.SetActive(health < maxhealth);
        }
        slidebar.value = health;
        slidebar.maxValue = maxhealth;

        slidebar.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slidebar.normalizedValue);
    }


    void Update()
    {
        slidebar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);  
    }
}
