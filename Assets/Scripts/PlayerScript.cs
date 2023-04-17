using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    ParticleSystem particles;
    SpriteRenderer sr;
    PolygonCollider2D pc2d;
    GameObject childThrust;
    ParticleSystem.EmissionModule pEmission;
    float force, yMove, xMove, speed;
    bool fire;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletTimeInverval = 0.1f;
    AudioSource shootSound;
    float bulletTime = 0;
    int score;
    float invulTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        pc2d = gameObject.GetComponent<PolygonCollider2D>();
        childThrust = transform.GetChild(0).gameObject;
        particles = gameObject.GetComponent<ParticleSystem>();
        pEmission = particles.emission;
        shootSound = GetComponent<AudioSource>();
        invulTime = 2f;
    }

    void CreateBullet()
    {
        GameObject newBullet = Instantiate(
            bullet, transform.position + transform.up * 4.5f, transform.rotation
            );
        newBullet.transform.GetComponent<SpriteRenderer>().color = sr.color;
        bulletTime = bulletTimeInverval;
        Destroy(newBullet, 0.7f);
        // Debug.Log("I shot a bullet");
    }
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Collectible")
        {
            Destroy(collider.gameObject);
            score++;
            Debug.Log($"Your score is: {score}");
        }
        if (collider.gameObject.tag == "BigAsteroid" || collider.gameObject.tag == "SmallAsteroid")
        {
            if (invulTime <= 0)
            {
                Destroy(gameObject);
                ShakeBehavior.instance.TriggerShake(0.5f);
                if (UIManager.instance.lives == 0)
                {
                    UIManager.instance.ShowGameover(Color.red);
                } else {
                    UIManager.instance.ShowRespawn();
                }
            }
            // Debug.Log($"Game Over");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            sr.color = Random.ColorHSV();
        }
        //if (Input.GetButtonUp("Jump"))
        //{
        //    rb.AddForce(new Vector2(0, force));
        //    force = 0;
        //}  

        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");
        fire = Input.GetButtonDown("Fire1");
        // fire = Input.GetButton("Fire1");
        
        speed = 55000f;

        //if (yMove > 0 && particles.isStopped)
        //{
        //    particles.Play();
        //}
        //if (yMove <= 0 && particles.isPlaying)
        //{
        //    particles.Stop();
        //}
        if (yMove > 0 && pEmission.enabled == false)
        {
            pEmission.enabled = true;
        }
        if (yMove <= 0 && pEmission.enabled == true)
        {
            pEmission.enabled = false;
        }
        //if (yMove > 0 && !particles.isEmitting)
        //{
        //  particles.Play();
        //}

        // Debug.Log($"{force}");

        if (fire && bulletTime <= 0)
        {
            CreateBullet();
            shootSound.Play();
        }
        bulletTime -= Time.deltaTime;
        invulTime -= Time.deltaTime;

        // gameObject.transform.Rotate(new Vector3(0f, 0f, -(Time.deltaTime * xMove * speed)));
        // non Rigidbody rotation ^

        // gameObject.transform.Translate(new Vector3(
        //    xMove * Time.deltaTime * speed, yMove * Time.deltaTime * speed, 0f
        //    ));
    }

    void FixedUpdate() 
    {
        if (yMove > 0)
        {
            force += 30f * Time.deltaTime;
            rb.AddForce(transform.up * yMove * force);

            if (force > 175)
            {
                force = 175;
            }

            childThrust.SetActive(true);
        } else {
            force -= 40f * Time.deltaTime;

            if (force < 75)
            {
                force = 75;
            }

            childThrust.SetActive(false);
        }

        rb.AddTorque(-(xMove * speed * Time.deltaTime));

    }
}
