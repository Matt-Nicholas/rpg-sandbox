using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject monster;
    [SerializeField] private bool respawn;
    [SerializeField] float spawnDelay;
    private float currentTime;
    private bool spawning;


	void Start ()
    {
        Spawn();
        currentTime = spawnDelay;
	}
	
	void Update ()
    {
        if(spawning)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                Spawn();
            }
        }
	}

    void Spawn()
    {
        IEnemy instance = Instantiate(monster, transform.position, Quaternion.identity).GetComponent<IEnemy>();
        instance.Spawner = this;

        spawning = false;
    }

    public void ReSpawn()
    {
        currentTime = spawnDelay;
        spawning = true;
    }
}
