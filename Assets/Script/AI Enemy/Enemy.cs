using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Transform Player;

    public UnityEvent<Vector2> OnMovementInput;
    public UnityEvent OnAttack;


    public float chaseDistanceThreshold = 1f, attackDistanceThreshold = 0.3f;

    public float attackDelay = 1;
    public float passTime = 1;

    public Vector2 vector2;
    void Update()
    {
        if (Player == null)
        {
            OnMovementInput?.Invoke(Vector2.zero);
            return;
        }

        float distance = Vector2.Distance(Player.position, transform.position);

        if (distance < chaseDistanceThreshold)
        {


            if (distance <= attackDistanceThreshold)
            {
                // attack the player
                OnMovementInput.Invoke(Vector2.zero);
                if (passTime >= attackDelay)
                {
                    passTime = 0;
                    OnAttack.Invoke();
                }
            }
            else
            {
                //chasing the player
                Vector2 v = (Player.position - transform.position) / Time.fixedDeltaTime;
                OnMovementInput.Invoke(v.normalized);
            }

        }
        if (distance > chaseDistanceThreshold)
        {

            OnMovementInput?.Invoke(Vector2.zero);
        }
        if (passTime <= attackDelay)
        {
            passTime += Time.deltaTime;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseDistanceThreshold);
        Gizmos.DrawWireSphere(transform.position, attackDistanceThreshold);
    }
}
