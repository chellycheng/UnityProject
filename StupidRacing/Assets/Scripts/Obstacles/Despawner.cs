using UnityEngine;

public class Despawner : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            //Debug.Log("GOT HERE");
            collision.gameObject.GetComponent<Obstacle>().Die();
        }
        else if (collision.tag == "Player")
        {
            //execute heart deduction

        }
    }
}
