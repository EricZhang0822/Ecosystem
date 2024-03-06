using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D _Wolf_Prey)
    {
        if(_Wolf_Prey.gameObject.tag == "Sheep")
        {
             GetComponent<Wolf>().ChangeToEatState();
        }
    }
}
