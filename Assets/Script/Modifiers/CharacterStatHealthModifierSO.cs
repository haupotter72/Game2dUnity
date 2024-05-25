using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStatHealthModifierSO : CharacterStarModifierSO
{
    public override void AffectCharacter(GameObject gameObject, float value) { 
        
        Health health = gameObject.GetComponent<Health>();
        if (health.currentHealth >= health.maxHealth)
        {
            health.currentHealth = health.maxHealth;
        }
        else
        {
            health.currentHealth += 2;
            health.healthBar.setHealth(health.currentHealth, health.maxHealth, health.gameObject);
        }

    }
}
