using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int health = 100;
    
    public void TakeDamage(int damage)
    {
        health -= damage;


        // if (health <= 1)
        //  {
        //     //Glowing animation
        //
        //if (melee) {Gkill();}            
        //   }else
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Gkill()
    {
        //code for glory kill
    }
}
