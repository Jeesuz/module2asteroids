using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] AudioSource explosionSound;
    ParticleSystem particles;
    ParticleSystem.EmissionModule pEmission;
    float force = 700f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    CircleCollider2D cc2d;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        particles = gameObject.GetComponent<ParticleSystem>();
        cc2d = gameObject.GetComponent<CircleCollider2D>();
        pEmission = particles.emission;
        pEmission.enabled = false;
        rb.AddForce(transform.up * force);
    }
    void BulletExplode(int score)
    {
        explosionSound.Play();
        sr.enabled = false;
        cc2d.enabled = false;
        pEmission.enabled = true;
        rb.velocity = new Vector2(0f, 0f);
        UIManager.instance.UpdateScore(score);
        Destroy(gameObject, 0.5f);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "BigAsteroid")
        {
            AsteroidBehavior bigAs = collider.GetComponent<AsteroidBehavior>();
            bigAs.KillSelf();
            ShakeBehavior.instance.TriggerShake(0.7f);
            BulletExplode(25);
        } else if (collider.gameObject.tag == "SmallAsteroid")
        {
            Destroy(collider.gameObject);
            ShakeBehavior.instance.TriggerShake(0.3f);
            BulletExplode(50);
        } 
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
