using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 2;
    public float jumpForce;
    public bool isGrounded = false;
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("kick");
        }
        else
        {
            speed = 0;
            anim.SetFloat("speed", speed);
        }
    }

    private void MoveLeft()
    {
        speed = 2;
        anim.SetFloat("speed", speed);
        Vector2 targetPos = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
    private void MoveRight()
    {
        speed = 2;
        anim.SetFloat("speed", speed);
        Vector2 targetPos = new Vector2(transform.position.x + 1, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
    private void Jump()
    {
        if (isGrounded == true)
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
}
