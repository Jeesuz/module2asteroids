using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBall : MonoBehaviour
{
    // [SerializeField] GameObject pivot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.transform.position, Vector3.forward, 250 * Time.deltaTime);
        transform.Rotate(0, 0, 100 * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, 40);

        transform.Translate(transform.up * 2f * Time.deltaTime);
    }
}
