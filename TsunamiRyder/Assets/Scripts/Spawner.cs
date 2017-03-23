using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1;

    //enemy prefab
    public GameObject enemy;

    //bounds of spawner
    public float leftBound = -5F;
    public float rightBound = 5F;


    // Use this for initialization
    void Start()
    {
        //call SpawnEnemy based on spawnRate
        InvokeRepeating("SpawnEnemy", 1, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        //a clone of the enemy prefab
        GameObject enemyClone;

        //spawns enemyClone at this location and rotation   
        enemyClone = Instantiate(enemy, this.transform.position, this.transform.rotation) as GameObject;

        //randomly moves spawner along x axis
        float x = Random.Range(leftBound, rightBound);
        transform.position = new Vector3(x, this.transform.position.y, 0);
    }
}