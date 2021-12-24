using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jump;
    Rigidbody2D rigidbody2D;
    int sayac;
    AttributeController attributeController;
    int sayac1;
    bool isShot;
    bool isTouch;
    float power;
    Rigidbody2D Ball;
    bool fly;
    bool ghost;
    bool dash;
    float dashTime;

    float geciciSpeed;

    private void Start()
    {
        geciciSpeed = speed;
        isShot = false;
        sayac = 0;
        rigidbody2D = GetComponent<Rigidbody2D>();
        attributeController = GetComponent<AttributeController>(); //Ayný script içerisinde olduðumuz için bu referansý almamýz için yeterli

        dashTime = 0.1f;
        //dash ve ghost gibi özelliklerde buradan eklenecek
        
    }
    private void Update()
    {
        if(attributeController.okunanBilgi != null)
        {
            fly = attributeController.Fly;
            ghost = attributeController.Ghost;
            dash = attributeController.Dash;
            speed = attributeController.okunanBilgi.speed;
            jump = attributeController.okunanBilgi.jump;
            power = attributeController.okunanBilgi.power;

        }  
    }

    private void FixedUpdate()
    {
        

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * 0.01f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * 0.01f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (sayac == 0)
            {
                sayac++;
                Vector2 a = new Vector2(transform.forward.x, 1f);
                rigidbody2D.velocity = a * jump;
            }
            if(fly == true)
            {
                Vector2 a = new Vector2(transform.forward.x, 1f);
                rigidbody2D.velocity = a * jump;
            }
            
        }
        if (Input.GetMouseButton(0) && isTouch == true)
        {
            shot();
        }

        if (ghost == true)
        {
            Debug.Log("HAYALET");
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -20f);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }

        if(dash == true)
        {
            if (Input.GetMouseButton(1))
            {
                dashTime -= Time.deltaTime;
                if(dashTime >= 0f)
                {
                    
                    transform.position += new Vector3(Input.GetAxis("Horizontal") * 0.05f * speed, Input.GetAxis("Vertical") * 0.05f * speed, 0f);

                }
                
            }
            else
            {
                dashTime = 0.1f;
            }
            if(Input.GetMouseButtonUp(1)){
                dashTime = 0.1f;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            sayac = 0;
        }
    }


    public void shot()
    {
        Vector3 vector3 = new Vector3(1f, 0.6f, 0);
        Ball.velocity = vector3 * power;
        isTouch = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            Ball = collision.gameObject.GetComponent<Rigidbody2D>();
            isTouch = true;           
        }
        
    }


    
}
