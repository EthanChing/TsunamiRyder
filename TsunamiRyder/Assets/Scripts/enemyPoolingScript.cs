using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class enemyPoolingScript : MonoBehaviour {
    
    public static enemyPoolingScript current;
    public GameObject pooledEnemy;
    public int poolAmount = 30;
    public bool willGrow = true;

    
    List<GameObject> pooledEnemys;

    void Awake()
    {
        current = this;
    }

	// Use this for initialization
	void Start ()
    {
        pooledEnemys = new List<GameObject>();
        GameObject[] enemies = Resources.LoadAll<GameObject>("Prefabs/Enemies");
        bool hasHouse = false;
        for (int i= 0; i < poolAmount; i++)
        {
            
            GameObject obj = Instantiate(enemies[Random.Range(0, enemies.Length)]);

          

            obj.SetActive(false);
            pooledEnemys.Add(obj);
        }

	}
    public GameObject getPooledEnemy()
    {
        /*for (int i = 0; i < pooledEnemys.Count; i++)
        {
            if (!pooledEnemys[i].activeInHierarchy)
            {
                return pooledEnemys[i];
            }
        }*/

        //Iterates through whole list to check if all are active, if yes then add new object to pool to spawn.
        if (pooledEnemys.TrueForAll((GameObject enemy) => { return enemy.activeInHierarchy; }))
        {


            GameObject obj = (GameObject)Instantiate(Resources.LoadAll<GameObject>("Prefabs/Enemies")[Random.Range(0, pooledEnemys.Count)]);
            pooledEnemys.Add(obj);
            return obj;

        }

        //Randomizes what object in pool to spawn to reduce spawning the same enemy.
        int index = Random.Range(0, pooledEnemys.Count);
        do
        {
            index = Random.Range(0, pooledEnemys.Count);
        }
        while (pooledEnemys[index].activeInHierarchy);
        return pooledEnemys[index];

        /*
        if (willGrow)
        {
           
        }*/
        return null;
    }
	
}
