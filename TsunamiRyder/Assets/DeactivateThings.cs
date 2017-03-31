using UnityEngine;
using System.Collections;

public class DeactivateThings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        
    }
}
