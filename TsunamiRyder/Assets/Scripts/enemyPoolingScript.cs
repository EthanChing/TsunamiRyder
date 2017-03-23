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
	void Start () {
        pooledEnemys = new List<GameObject>();
        for(int i= 0; i< poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledEnemy);
            obj.SetActive(false);
            pooledEnemys.Add(obj);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
