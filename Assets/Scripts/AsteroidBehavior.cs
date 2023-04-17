using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] float force = 3000f;
    [SerializeField] float torque = 100f;
    [SerializeField] GameObject smallAsteroid;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;

        rb.AddForce(direction * force);
        rb.AddTorque(Random.Range(-1f, 1f) * torque);
    }

    public void KillSelf() 
    {
        AsteroidsSpawn();
        Destroy(gameObject);
    }

    void AsteroidsSpawn()
    {
        GameObject newAsteroid1 = Instantiate(smallAsteroid, transform.position, transform.rotation);
        GameObject newAsteroid2 = Instantiate(smallAsteroid, transform.position, transform.rotation);
        GameObject newAsteroid3 = Instantiate(smallAsteroid, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
