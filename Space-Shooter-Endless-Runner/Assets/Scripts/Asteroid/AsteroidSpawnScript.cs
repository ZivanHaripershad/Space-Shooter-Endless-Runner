using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour
{
    public GameObject enemySpawner;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.instance.getIsPlayerStillAlive()){
            if(Time.time > spawnTime){
                Spawn();
                spawnTime = Time.time + timeBetweenSpawn;
            }
        }
        
    }

    void Spawn(){
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(enemySpawner, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
