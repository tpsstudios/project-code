using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Rigidbody2D rb;
    public int damage = 1;


    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(BulletControl());
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);


    }

    public IEnumerator BulletControl()
    {

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
