using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechaEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float radius;
    public float distanceAttack;
    private Animator animator;
    private Rigidbody2D rb;
    private float time = 0;
    public float delay;
    public GameObject buleltParent;
    public GameObject bullet;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
     
         foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position,radius))
        {
            if (col.name == "Player" && col.tag == "Player")
            {
                float dis = Vector2.Distance(transform.position, player.transform.position);
                if(dis < radius)
                {
                    if(distanceAttack > dis)
                    {
                        if (time > delay)
                        {
                            move(Vector2.zero);
                            attack();
                            time = 0;
                            Debug.Log("Attack");
                        }
                        else
                        {
                            time += Time.deltaTime;
                        }                     
                       
                    }
                    else
                    {
                        Vector2 movement = (player.transform.position - transform.position) * speed * Time.deltaTime;
                        move(movement.normalized);
                      
                    }
                
                }
                else
                {
                    move(Vector2.zero);
                }
               
            }           
           
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,radius);
        Gizmos.DrawWireSphere(transform.position,distanceAttack);
       
    }

    public void attack()
    {
        animator.SetTrigger("attack");
        Instantiate(bullet, buleltParent.transform.position, Quaternion.identity);
    }
    public void move(Vector2 movement)
    {
        if (movement != Vector2.zero)
        {
            if (movement.magnitude > 0)
            {
                if (movement.x > 0)
                {
                    transform.localScale = new Vector3(3, 3, 1);

                }
                else if (movement.x < 0)
                {
                    transform.localScale = new Vector3(-3, 3, 1);

                }
                rb.velocity = speed * movement;
           
            }
            else
            {
                rb.velocity = speed * Vector2.zero;
            
            }

        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

}
