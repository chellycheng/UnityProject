using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
  public float health = 100;
  public bool hitable;

  public void TakeDamage(float damage) {
      if (hitable) {
          health -= damage;
          if (health <= 0) {
              Die();
          }
      }
  }

  public void Die() {
      //Instantiate(deathEffect, transform position, qQuaternion.identity);
      Destroy(gameObject);
  }
}
