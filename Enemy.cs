using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    private Transform target;
    public float speed;
    SpriteRenderer sprite;
    public int damage = 10;
    public Rigidbody2D rb2d;
    


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        


    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }


    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }



    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        carController carController = hitInfo.GetComponent<carController>();
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        if (carController != null)
        {
            carController.PlayerTakeDamage(damage);
        }
        if (bullet != null)
        {

            StartCoroutine(Flash());




        }
    }

    public IEnumerator Flash()
    {
        rb2d.AddForce(transform.up * 0.01f, ForceMode2D.Impulse);
        sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.01f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(1f);
        rb2d.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);



    }
    

}
