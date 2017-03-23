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
        for(int i= 0; i< poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledEnemy);
            obj.SetActive(false);
            pooledEnemys.Add(obj);
        }

	}
    public GameObject getPooledEnemy()
    {
        for( int i= 0; i< pooledEnemys.Count; i++)
        {
            if(!pooledEnemys[i].activeInHierarchy)
            {
                return pooledEnemys[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledEnemy);
            pooledEnemys.Add(obj);
            return obj;
        }
        return null;
    }
	
}
