using UnityEngine;
using InControl;
using System.Collections;


public class Player1Controller : MonoBehaviour {
    private Rigidbody myRigidbody;
    public float speed;
    public float thrust;

    public int playerNum;
    private InputDevice controller;
    
    public float waveForce;
    public Transform spawnPoint;
   

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        controller = InputManager.Devices[playerNum];
	}
	
	// Update is called once per frame
	void Update () {
        var x =  controller.LeftStick.X * speed;
        if (controller.Action1.WasPressed)
        {
            myRigidbody.AddForce(0, -thrust, 0);
        }

        myRigidbody.AddForce(0, waveForce, 0);
        myRigidbody.velocity = new Vector3(x, myRigidbody.velocity.y, myRigidbody.velocity.z);

        if (controller.Action4.WasPressed)
        {
            transform.position = spawnPoint.position;
            myRigidbody.velocity = new Vector3();
        }
        
      

    }
}
