using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHelper : MonoBehaviour
{
   
    public Enemy enemy;
    public void DelectColliders()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, enemy.attackDistanceThreshold);

        Health health = col.GetComponent<Health>();
        if (health)
        {
            health.GetHit(1, gameObject);
        }
      
    }
}
