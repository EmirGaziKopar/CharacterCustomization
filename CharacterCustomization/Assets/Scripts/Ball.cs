using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    GameManager gm;
    Vector2 startPos;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "PortaPlayer")
        {

            gm.aiScore++;
            rb.velocity = Vector2.zero;
            transform.position = startPos;
        }
        else if (collision.gameObject.name == "PortaEnemy")
        {
            gm.playerScore++;
            rb.velocity = Vector2.zero;
            transform.position = startPos;
        }
    }
}
