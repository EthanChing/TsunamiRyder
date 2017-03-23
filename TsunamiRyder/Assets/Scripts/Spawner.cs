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
    public float leftBoundy = 1f;
    public float rightBoundy = 3f;


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
        GameObject obj = enemyPoolingScript.current.getPooledEnemy();

        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.SetActive(true);

        //randomly moves spawner along x axis
        float x = Random.Range(leftBound, rightBound);
        transform.position = new Vector3(x, this.transform.position.y, 0);
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        float randY = Random.Range(leftBoundy, rightBoundy);
        rb.AddForce(transform.up * randY);
    }
}