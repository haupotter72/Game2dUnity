using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    public float dame;
    public Transform circleOrigin;
    public float radius;


    public void DelectColliders()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            Health health = col.GetComponent<Health>();
            if (health)
            {
                health.GetHit(1, transform.parent.gameObject);
            }

        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(circleOrigin.position, radius);
    //}
}
