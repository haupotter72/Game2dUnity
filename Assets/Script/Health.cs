using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    public bool isDeath = false;

    public HealthBar healthBar;

    public GameObject Potion;

    public GameOverScreen gameOver;

    private void Start()
    {
        healthBar.setHealth(currentHealth, maxHealth, gameObject);
    }

    public void InitializeHealth(int HeathValue)
    {
        currentHealth = HeathValue;
        maxHealth = HeathValue;
        isDeath = false;
       
    }


    public void GetHit(int amount, GameObject sender)

    {
        if (isDeath)
        {
       
            return;
        }


        if (sender.name == gameObject.name)
        {
            return;
        }
        currentHealth -= amount;
        Debug.Log(gameObject.name + " : " + currentHealth);
        healthBar.setHealth(currentHealth, maxHealth, gameObject);

        if (currentHealth > 0)
        {
            OnHitWithReference.Invoke(sender);
        }
        else
        {
            
            OnDeathWithReference.Invoke(sender);
            isDeath = true;

            StartCoroutine(delayTime());
           
           
        }

    }

    IEnumerator delayTime()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(1);
        print(Time.time);
        Instantiate(Potion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (gameObject.tag == "Player")
        {
            gameOver.isActive();
        }
    }
}
