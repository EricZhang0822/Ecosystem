using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDeadDetect : MonoBehaviour
{
    private bool eaten = false;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D _Animal)
    {
       
          if (_Animal.gameObject.tag == "Wolf" && !Wolf.wolf_reference.satisfied)
          {
              if (!eaten)
              {
                eaten = true;
                Wolf.wolf_reference.EatSheepNum += 1;
                  GetComponent<Sheep>().ChangeToCorpseState();
              }
          }

          if (_Animal.gameObject.tag == "Vulture" && GetComponent<Sheep>().stateMachine.currentState == GetComponent<Sheep>().cspState)
          {
              if (!dead)
              {
                dead = true;
                GetComponent<Sheep>().ChangeToDeadState();
              }
          }
       
    }
}
