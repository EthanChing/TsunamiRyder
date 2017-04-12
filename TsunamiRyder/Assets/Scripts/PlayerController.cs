using UnityEngine;
using InControl;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public float speed;
    public float thrust;
    public float leftBound = -8;
    public float rightBound = 8 ;

    public int playerNum;
    public InputDevice controller;
    
    public float waveForce;
    public Transform spawnPoint;
   

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        controller = InputManager.Devices[playerNum];
	}

    // Update is called once per frame
    void Update() {
        var x = controller.LeftStick.X * speed;
        if (controller.Action1.WasPressed || Input.GetKeyDown("space"))
        {
            myRigidbody.AddForce(new Vector3(0, -thrust));
        }

        myRigidbody.AddForce(new Vector2(0, waveForce));
        myRigidbody.velocity = new Vector2(x, myRigidbody.velocity.y);

        if (controller.Action4.WasPressed)
        {
            transform.position = spawnPoint.position;
            myRigidbody.velocity = new Vector3();
        }

        if (controller.Action2.WasPressed)
        {
            myRigidbody.AddForce(new Vector2(0, thrust*2));
            
        }
           
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, 0);
        }
        else if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, 0);
        }
      

    }
}
