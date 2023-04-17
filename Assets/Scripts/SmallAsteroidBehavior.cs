using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroidBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] float force = 3500f;
    [SerializeField] float torque = 500f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;

        rb.AddForce(direction * force);
        rb.AddTorque(Random.Range(-1f, 1f) * torque);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
