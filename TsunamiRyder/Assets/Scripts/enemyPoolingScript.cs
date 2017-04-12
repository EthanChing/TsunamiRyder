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
        //MAke the TAGS !!!!
        Dictionary<string, int> enemyCounts = new Dictionary<string, int>()
        {
            {"house", 1 },
            {"cow", 4 },
            {"nuke",1 },
            {"theDonal",1 },
            {"shark",3 },
            {"car", 4 }

        };

        for (int i= 0; i < enemies.Length; i++)
        {
            for (int nEnemies = 0; nEnemies < enemyCounts[enemies[i].tag]; nEnemies++)
            {
                GameObject obj = Instantiate(enemies[i]);
                obj.SetActive(false);
                pooledEnemys.Add(obj);
            }
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
        //This can become infinite loop if none found, but that precaution is made in above if statement.
        while (pooledEnemys[index].activeInHierarchy);

        return pooledEnemys[index];

        /*
        if (willGrow)
        {
           
        }*/
        return null;
    }
	
}
