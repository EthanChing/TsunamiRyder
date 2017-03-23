using UnityEngine;
using System.Collections;
using InControl;

public class Rotation : MonoBehaviour {
    public int playerNum;
    private InputDevice controller;
    public float maxAngle;
    public float rotationDrift;
    public float turnDrift;
    private float angle;
    public float flipAngle;

    // Use this for initialization
    void Start () {
        controller = InputManager.Devices[playerNum];

    }
	
	// Update is called once per frame
	void Update () {
        if (controller.LeftStick.Vector.magnitude > 0.5)
        {
            angle = Mathf.Lerp(angle, Mathf.Clamp(-controller.LeftStick.Angle + 180, -maxAngle, maxAngle), turnDrift * Time.deltaTime);
        }
        else
        {
            angle = Mathf.Lerp(angle, 0, rotationDrift * Time.deltaTime);
            
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // doing the sprite flip here
        if (angle > flipAngle)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }
        else if (angle < -flipAngle)
        {
            transform.localScale = new Vector3(- Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }

    }
}
