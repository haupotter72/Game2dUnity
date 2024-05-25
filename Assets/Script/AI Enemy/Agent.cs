using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private Vector2 movement;
    public float speed;
    public Vector2 Movement { get => movement; set => movement = value; }
    public Vector3 scale;
    private Rigidbody2D rb;
    private Animator animator;
    public float lastSwing;
    public float coolDown = 0.2f;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }


    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            if (movement.magnitude > 0)
            {
                if (movement.x > 0)
                {
                    transform.localScale = new Vector3(scale.x, scale.y, scale.z);

                }
                else if (movement.x < 0)
                {
                    transform.localScale = new Vector3(-scale.x, scale.y, scale.z);

                }
                rb.velocity = speed * movement;
                animator.SetBool("isMoving", true);
            }
            else
            {
                rb.velocity = speed * Vector2.zero;
                animator.SetBool("isMoving", false);
            }

        }
        else
        {
            animator.SetBool("isMoving", false);
            rb.velocity = speed * Vector2.zero;
        }

    }

    public void PerformAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void Die()
    {
        animator.SetBool("isDie", true);
    }


}
