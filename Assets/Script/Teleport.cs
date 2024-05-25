using Inventory;
using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public InventorySO inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            var count = 0;
            var items = inventory.GetCurrentInventoryState();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].item.name == "Earth Magic Stone")
                {
                    count += 1;
                }
                if (items[i].item.name == "Fire Magic Stone")
                {
                    count += 1;
                }
                if (items[i].item.name == "Ice Magic Stone")
                {
                    count += 1;
                }
                if (items[i].item.name == "Natural Magic Stone")
                {
                    count += 1;
                }
            }


            if(count == 4)
            {
                StartCoroutine(delayTime());
            }
            else
            {
                Debug.Log("Vui long tim kiem them da");
            }      

        }
    }
    IEnumerator delayTime()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        print(Time.time);
      
    }
}
