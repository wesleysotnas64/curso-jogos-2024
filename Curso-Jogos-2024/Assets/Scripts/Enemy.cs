using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocity;
    public Vector2 direction;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerDirection();
        FlipEnemy();
        EnemyMove();
    }

    public void EnemyMove()
    {
        direction = direction * velocity * Time.deltaTime;
        transform.Translate(direction.x, direction.y, 0);
    }

    public void PlayerDirection()
    {
        Vector2 newDirection = Vector2.zero;

        GameObject player = GameObject.Find("Player");

        newDirection = new Vector2
        (
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y
        );

        direction = newDirection.normalized;
    }

    public void FlipEnemy()
    {
        if(direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        Destroy(this.gameObject);
    }
}
