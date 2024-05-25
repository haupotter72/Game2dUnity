using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bullet : MonoBehaviour
{
    Transform target;
    public float speed;
    private Vector2 Vector2;
    public int dame;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 = new Vector2(target.position.x, target.position.y);     
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2, speed * Time.deltaTime);
        if (Vector2.x == transform.position.x && Vector2.y == transform.position.y)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {  
            Health heal = collision.GetComponent<Health>();
            heal.GetHit(1, gameObject);
            Debug.Log("Trung");
            Destroy(gameObject);
        }
    }

}
