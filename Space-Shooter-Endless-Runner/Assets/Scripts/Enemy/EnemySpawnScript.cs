using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject enemySpawner;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    private float difficultyIncreaser;
    private bool decreasedDifficulty;
    private float previousTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 0f;
        decreasedDifficulty = false;
        previousTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.instance.getIsPlayerStillAlive()){
            float currentTime = Mathf.CeilToInt(Time.time);

            if(currentTime > previousTime){
                decreasedDifficulty = false;
            }

            if(IsDivisibleBy20(currentTime) && decreasedDifficulty == false && timeBetweenSpawn > 0){
                timeBetweenSpawn -= 0.1f;
                previousTime = currentTime;
                decreasedDifficulty = true;
            }

            if(currentTime > spawnTime){
                Spawn();
                spawnTime = currentTime + timeBetweenSpawn;
            }
        }
        
    }

    void Spawn(){
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(enemySpawner, transform.position + new Vector3(x, y, 0), transform.rotation);
    }

    bool IsDivisibleBy20(float number)
    {
        return number % 20 == 0;
    }
    
}
