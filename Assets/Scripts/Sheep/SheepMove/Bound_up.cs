using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound_up : MonoBehaviour
{
    private float Speed = 1.3f;
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
            _sheepRb.velocity = new Vector2(Random.Range(-Speed,Speed), Random.Range(-.25f, -.1f));
        }
    }
}
