﻿using UnityEngine;
using System.Collections;

public class enemyDeactivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (transform.position.y >3.2 && transform.position.y <-6 && transform.position.x >7 && transform.position.x <-7 )
        {
            gameObject.SetActive(false);
            Debug.Log("zap");
        }
	}
}
