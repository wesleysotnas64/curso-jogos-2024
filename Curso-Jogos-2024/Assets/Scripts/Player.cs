using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public Vector2 direction;
    public GameObject target;
    public GameObject shuriken;

    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
        MouseDirection();

        target.GetComponent<Transform>().up = direction;
        
        FlipPlayer();
        ThrowShuriken();
    }

    public void MovePlayer()
    {
        if(Input.GetKey("w") && transform.position.y < 17)
        {
            transform.Translate(0, velocity * Time.deltaTime, 0);
        }
        if(Input.GetKey("s") && transform.position.y > -12)
        {
            transform.Translate(0, -velocity * Time.deltaTime, 0);
        }
        if(Input.GetKey("d") && transform.position.x < 27)
        {
            transform.Translate(velocity * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey("a") && transform.position.x > -27)
        {
            transform.Translate(-velocity * Time.deltaTime, 0, 0);
        }
    }

    public void MouseDirection()
    {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        Vector2 newDirection = new Vector2
        (
            mouse.x - transform.position.x,
            mouse.y - transform.position.y
        );

        direction = newDirection.normalized;
    }

    public void ThrowShuriken()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject shurikenGameObject = Instantiate(shuriken);
            shurikenGameObject.transform.position = transform.position;
            shurikenGameObject.transform.up = direction;
        }
    }

    public void FlipPlayer()
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

}
