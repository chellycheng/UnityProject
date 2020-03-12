using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float health = 100;
    public bool hitable;

    public void TakeDamage(float damage)
    {
        if (hitable)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        //Instantiate(deathEffect, transform position, qQuaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log(c.gameObject.tag);

        if (c.gameObject.tag.Equals("Player"))
        {
            TakeDamage(999);
            // Destroy the player and also the object
            Destroy(c.gameObject);
            //TODO:add blinking, health system
        }

        else if (c.gameObject.tag.Equals("bullet")) {

            Bullet b =  c.gameObject.GetComponent<Bullet>();
            Debug.Log(b.damage);
            TakeDamage(b.damage);

        }
        

    }
}