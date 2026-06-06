using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rb;

    public float movespeed;
    public float jumpforce;
    bool isjump;

    public Vector2 nextstorypos;
    public int walks;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            Jumping();
        }

        if(walks == 0)
        {
            nextstorypos = gameObject.transform.position;
        }

        Clamped();
    }

    void Moving()
    {
        float x = Input.GetAxis("Horizontal");

        if (x != 0)
        {
            if (x < 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            float move = 0;
            if (GetComponent<Player>().iscanrun)
            {
                move = movespeed;
            }
            else
            {
                return;
            }
            if (isjump)
            {
                move = move / 1.5f;
            }

            rb.velocity = new Vector2(x * move, rb.velocity.y);
            walks++;
        }

        Clamped();
    }

    void Jumping()
    {
        if (!isjump && GetComponent<Player>().iscanrun)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    void Clamped()
    {
        float posx = Mathf.Clamp(gameObject.transform.position.x, -8.66f, 10000f);
        rb.position = new Vector2(posx, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            isjump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            isjump = true;
        }
    }
}
