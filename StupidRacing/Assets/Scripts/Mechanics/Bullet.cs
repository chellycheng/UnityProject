
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float damage;
    private float speed;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Init(Gun gun)
    {
        speed = gun.speed;
        damage = gun.damage;
    }

    public void InitMove(Vector3 direction)
    {
        //transform.Rotate(transform.rotation.eulerAngles);
        print(direction.y);
        rb.velocity = new Vector3(0, speed, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        //
        
        Destroy(gameObject);
    }
}
