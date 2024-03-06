using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound_right : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D animal)
    {
        
        if (animal.gameObject.tag == "Sheep")
        {
            Debug.Log("collided");
            Rigidbody2D _sheepRb = animal.gameObject.GetComponent<Rigidbody2D>();
            _sheepRb.velocity = new Vector2(Random.Range(-1.3f, -.8f), Random.Range(.5f,-.5f));
        }
        if (animal.gameObject.tag == "Wolf")
        {
            Debug.Log("collided");
            Rigidbody2D _wolfRb = animal.gameObject.GetComponent<Rigidbody2D>();
            _wolfRb.velocity = new Vector2(Random.Range(-1.3f, -.8f), Random.Range(-.3f, 0f));
        }
    }
}
