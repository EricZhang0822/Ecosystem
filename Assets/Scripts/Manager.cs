using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject wolf_instance;
    public GameObject vulture_instance;
    public Transform wolf_area;
    public Transform Vultures;
    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> dead_targets = new List<GameObject>();
    public float wolf_findTimer = 0;
    public float vulture_timer = 2;
    public static Manager reference;
    private bool wolf_exist = false;
    private float wolf_spawnTime = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        reference = this;
    }

    // Update is called once per frame
    void Update()
    {
        wolf_findTimer -= Time.deltaTime;
        vulture_timer -= Time.deltaTime;
        if (SheepManager.SheepCount >= 5) // if herd >= 5 sheep
        {
            if(!wolf_exist)
                wolf_spawnTime -= Time.deltaTime;

            if(wolf_spawnTime < 0){ //wait for time to spawn wolf
                if (!wolf_exist)
                {
                    wolf_spawn();
                    wolf_spawnTime = 5f;
                }
            }
            
        }

        if(wolf_findTimer < 0)
        {
            wolf_findTimer = 2f;
            if (GameObject.FindGameObjectsWithTag("Wolf") == null)
            {
                Debug.Log("null");
                wolf_exist = false;

            }
        }

        if(dead_targets.Count != 0 && vulture_timer < 0)
        {
            vulture_timer = 15;
            vulture_spawn();
        }
    }

    private void wolf_spawn()
    {
        GameObject.Instantiate(wolf_instance, new Vector3(Random.Range(-8, -5), Random.Range(2f, 3f), 0), Quaternion.identity, wolf_area);
        wolf_exist = true;
    }

    private void vulture_spawn()
    {
        GameObject.Instantiate(vulture_instance, new Vector3(Random.Range(-2, 2), Random.Range(2.5f, 3.5f), 0), Quaternion.identity, Vultures);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sheep")
        {
            SheepManager.SheepCount--;
        }
       GameObject.Destroy(collision.gameObject);
    }
}
