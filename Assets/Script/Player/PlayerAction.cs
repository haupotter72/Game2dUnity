using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
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
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            dir.x = -1;
            //animator.SetInteger("Direction", 3);
            animator.SetInteger("Direction", 2);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }
        dir.Normalize();
        animator.SetBool("isMoving", dir.magnitude > 0);

        rb.velocity = speed * dir;
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
