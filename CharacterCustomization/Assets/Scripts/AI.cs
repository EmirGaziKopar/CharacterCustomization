using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public float rangedDefence, speed;
    public Transform defence;
    public GameObject Ball;
    Rigidbody2D rb;

    public float jumpForce;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {

        Ball = GameObject.FindGameObjectWithTag("Ball");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Move();

        Jump();
    }

    private void Move()
    {

        if (Mathf.Abs(Ball.transform.position.x + transform.position.x) > rangedDefence)
        {

            if (Ball.transform.position.x > transform.position.x)
            {
                transform.Translate(Time.deltaTime * speed, 0,0);
            }
            else if (Ball.transform.position.x < transform.position.x)
            {
                transform.Translate(-Time.deltaTime * speed, 0, 0);
            }
            else if (Ball.transform.position.x == transform.position.x)
            {
                transform.position = new Vector2(transform.position.x + 1.5f, transform.position.y);
            }
        }
        else
        {

            if (transform.position.x < defence.position.x)
            {
                transform.Translate(Time.deltaTime * speed, 0, 0);
            }
            else
            {
                transform.Translate(0, 0, 0);
            }
        }
    }

    private void Jump()
    {

        float dist = Vector2.Distance(Ball.transform.position, transform.position);

        if (dist < 1f && isGrounded == true)
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "terreno")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "terreno")
        {
            isGrounded = false;
        }
    }
}
