using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D body;
    public int health;
    public bool hitable = true;

    public bool isCar;
    public SpawnPoint lane;

    private float downSpeed;



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        downSpeed = GameControl.Instance.scrollSpeed;

        if (isCar)
        {
            body.velocity = new Vector2(0, -downSpeed + Random.Range(0,6.0f));
        }
        else
        {
            body.velocity = new Vector2(0, -downSpeed);
        }
        
    }
    public void TakeDamage(int damage) {
        if (hitable) { 
            health -= damage;
            if (health <= 0) {
                Die();
            }
        }
    }

    public void Die() {
        //Instantiate(deathEffect, transform position, qQuaternion.identity);
        lane.occupied = false;
        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        //deduct one heart and respawn
    //    }
    //    else if (other.tag == "Projectile")
    //    {
    //        //TakeDamage(projectile damage);
    //    }
    //}
}
