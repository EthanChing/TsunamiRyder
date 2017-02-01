using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var y = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var x = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(y, x, 0);
        

    }
}
