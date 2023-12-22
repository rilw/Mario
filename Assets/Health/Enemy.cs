using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float moveDistance;
    [SerializeField] private float speed;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    public int health;
    public GameObject DroppedCoin;
    private void Awake()
    {
        leftEdge = transform.position.x - moveDistance;
        rightEdge = transform.position.x + moveDistance;
    }

    private void Update()
    {
       if(movingLeft)
        {
            if(transform.position.x>leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }

        if (health < 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);

        }
        if (collision.CompareTag("bullet"))
        {
            health = health - 1;
        }
    }

    void hilka()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(DroppedCoin, transform.position, transform.rotation);
        }
    }
}
