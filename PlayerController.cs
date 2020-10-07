using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;            //Define the variable as public so we can change it in the GUI**
    private Rigidbody2D rb2d;
    Vector2 move;
    public GameObject particleTrail;  //Define the variable as public so we can reference it in the GUI**
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;
    public bool isGrounded;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();  //Define the variable for rb2d at the beginning of the game**
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        move.x = Input.GetAxisRaw("Horizontal");     //Records X-Axis Input**
        Vector2 movement = new Vector2(move.x, 0);   //Sets Movement on X-Axis**
        rb2d.AddForce(movement * speed);             //Apply Force from Movement * Speed**



        if (move.x > 0.01f)                          //Flip the sprite of the player**
        {

            spriteRenderer.transform.Rotate(Vector3.back);
        }
        else if (move.x < -0.01f)
        {

            spriteRenderer.transform.Rotate(Vector3.forward);
        }
        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb2d.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        


    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name == "Tilemap")
        {
            isGrounded = true;
        }
    }

    //Set isGrounded to False, if player leaves the Tilemap
    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name == "Tilemap")
        {
            isGrounded = false;
        }
    }

}
