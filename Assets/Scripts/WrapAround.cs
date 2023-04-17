using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    float halfScreenW = 130f;
    float halfScreenH = 71f;
    [SerializeField] float size;
    Vector3 xVec, yVec;
    // Start is called before the first frame update
    void Start()
    {
        xVec = Vector3.right * (halfScreenW + size) * 2;
        yVec = Vector3.up * (halfScreenH + size) * 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > (halfScreenW + size))
        {
            // transform.position -= new Vector3(halfSCreenW * 2, 0, 0);
            transform.position -= xVec;
        }
        if (transform.position.x < -(halfScreenW + size))
        {
            transform.position += xVec;
        }
        if (transform.position.y > (halfScreenH + size))
        {
            transform.position -= yVec;
        }
        if (transform.position.y < -(halfScreenH + size))
        {
            transform.position += yVec;
        }
    }
}
