using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy1 enemy = collision.GetComponent<Enemy1>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(collision.gameObject.tag == "suit")
        {

        }
        else {Destroy(gameObject); }
        
    }
}
