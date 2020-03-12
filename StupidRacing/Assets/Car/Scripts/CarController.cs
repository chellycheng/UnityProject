using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CarController : MonoBehaviour
{
    [Header("Utils")]
    public PlayerId id;
    public Cars cars;
    public Guns guns;
    public float spawnOffset = 6;
    bool PlayerState = true;

    [Header("UI")]
    public SpriteRenderer carView;
    public SpriteRenderer gunView;

    [Header("Physisc")]
    private Rigidbody2D body;
    public float downForce;
    public float fowardSpeed;
    public float turnSpeed;
    public float maxSpeed;

    [Header("Keys")]
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;
    public KeyCode shoot;

    [Header("Health")]
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private bool invincible;
    private float invincibilityTimeElapsed = 0;
    public float invincibilityTime;
    private float blinkingTimeElapsed = 0;
    public float blinkingTime;

    private bool moving = false;
    private float rotation = 10;
    private Vector3 downVector;
    private Vector3 velocity = Vector3.zero;

    private float elapsedTime = 0f;

    void Start()
    {
        downVector = new Vector3(0, -downForce, 0);
        Init();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (!moving)
        {
            body.velocity = Vector2.zero;

            if (id == PlayerId.Player1)
            {
                transform.position = new Vector2(-spawnOffset, 0);
            }
            else
            {
                transform.position = new Vector2(spawnOffset, 0);
            }
        }

        MoveCar();

        if (invincible)
        {
            DoReset();
        }

        DisplayHearts();
    }

    void MoveCar()
    {
        velocity += downVector;

        if (Input.GetKey(up))
        {
            velocity += fowardSpeed * Vector3.up;
            moving = true;
        }

        if (Input.GetKey(shoot))
        {
            if (elapsedTime > gun.rechargeTime)
            {
                elapsedTime = 0f;
                Shoot();
                moving = true;
            }
        }

        if (Input.GetKey(left))
        {
            velocity += turnSpeed * Vector3.left;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(-0.5f, 1));
            moving = true;
        }
        else if (Input.GetKey(right))
        {
            velocity += turnSpeed * Vector3.right;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(0.5f, 1));
            moving = true;
        }
        else
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.up);
        }

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        if (!moving) return; //don't update velocity if not moving

        body.velocity = velocity/10;
    }

    private void DisplayHearts()
    {
        for(int i=0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


    Car car;
    Gun gun;
    public void Init()
    {
        string g = id.ToString() + "_gun";
        string c = id.ToString() + "_car";
        string name = id.ToString() + "_name";
        int gunIndex = PlayerPrefs.GetInt(g);
        int carIndex = PlayerPrefs.GetInt(c);
        string displayName = PlayerPrefs.GetString(name);

        car = cars.carChoices[carIndex];
        gun = guns.gunChoices[gunIndex];

        carView.sprite = car.image;
        gunView.sprite = gun.image;

        fowardSpeed = car.speed;
    }

    Transform firepoint;
    public void Shoot()
    {
        float y = 2; // gunView.size.y / 2;
        Vector3 position = transform.position + new Vector3(0, y, 0);

        GameObject gameObject = GameObject.Instantiate(gun.bulletPrefab);

        gameObject.transform.position = position;
        gameObject.transform.Rotate(transform.rotation.eulerAngles);

        Bullet bullet = gameObject.GetComponent<Bullet>();
        bullet.Init(gun);
        bullet.InitMove(transform.forward);
        /*
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up);
        Debug.Log(hitInfo);
        if (hitInfo) {
            Obstacles ob = hitInfo.transform.GetComponent<Obstacles>();
            Debug.Log(ob);
            if (ob != null) {
                ob.TakeDamage(gun.damage);
                Debug.Log("happeen");
            }
        }
       */
    }

    private void DoReset()
    {
        //make blink
        if(invincibilityTimeElapsed > invincibilityTime)
        {
            invincibilityTimeElapsed = 0;
            carView.enabled = true;
            gunView.enabled = true;
            invincible = false;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            if(blinkingTimeElapsed > blinkingTime)
            {
                blinkingTimeElapsed = 0;
                carView.enabled = !carView.enabled;
                gunView.enabled = !gunView.enabled;
            }
            else
            {
                blinkingTimeElapsed += Time.deltaTime;
            }
            invincibilityTimeElapsed += Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Friendly" && !invincible)
        {
            moving = false;
            invincible = true;
            health -= 1;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        GameOver();
    }

    private void GameOver() {
        if (health <= 0) {
            PlayerState = false;
            if (id == 0)
            {
                ResultDisplay.loser = "Player1";
                ResultDisplay.winner = "Player2";
            }
            else {
                ResultDisplay.loser = "Player2";
                ResultDisplay.winner = "Player1";
            }

            SceneManager.LoadScene("GameOverScene");
        }
    }

    public bool checkState() {

        return PlayerState;
    }
}
