﻿using UnityEngine;
using System.Collections;

public class enemyDeactivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (transform.position.y >7)
        {
            gameObject.SetActive(false);
        }
	}
}
