using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCode : MonoBehaviour
{
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject enemyAsteroid;
    [SerializeField] GameObject enemyUfo;
    Rigidbody2D ufoRb;
    SpriteRenderer ufoSr;
    Vector2 distanceCoord;
    Vector2 playerPos, ufoPos;
    Vector3 playerPos3;
    Color ufoOgColor;
    Vector2 ufoDirection;
    [SerializeField] GameObject bullet;
    [SerializeField] float ufobulletTimeInterval = 0.5f;
    float ufobulletTime = 0f;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        ufoRb = enemyUfo.GetComponent<Rigidbody2D>();
        ufoSr = enemyUfo.GetComponent<SpriteRenderer>();
        ufoOgColor = ufoSr.color;
    }

    void CreateUfoBullet()
    {
        GameObject newUfoBullet = Instantiate(
            bullet, enemyUfo.transform.position + enemyUfo.transform.up * 0.1f, enemyUfo.transform.rotation
            );
        newUfoBullet.transform.GetComponent<SpriteRenderer>().color = ufoOgColor;
        ufobulletTime = ufobulletTimeInterval;
        Destroy(newUfoBullet, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerShip.transform.position;
        playerPos3 = playerShip.transform.position;
        ufoPos = enemyUfo.transform.position;
        distanceCoord = playerPos - ufoPos;
        distance = Vector2.Distance(playerPos, ufoPos);
        ufoDirection = (playerPos - ufoPos).normalized;
        Debug.Log(distance);
        // Debug.Log(distanceCoord);
 
        if (distance < 50)
        {
            ufoRb.AddForce(-ufoDirection * 5000f * Time.deltaTime);
            ufoSr.color = Color.red;
        } else {
            ufoSr.color = ufoOgColor;
        }

        enemyUfo.transform.up = ufoDirection;
        
        

        if (ufobulletTime <= 0)
        {
            CreateUfoBullet();
        }
        ufobulletTime -= Time.deltaTime;
        
    }
}
