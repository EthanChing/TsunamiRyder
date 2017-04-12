using UnityEngine;
using System.Collections;
using InControl;

public class TimeRewind : MonoBehaviour
{

   
    private InputDevice controller;
    public int playerNum;
    private Vector3 lastPoint;
    private float currentTime;
    public float maxTime;

    void Update()

    {

        controller = InputManager.Devices[playerNum];
        currentTime += Time.deltaTime;
        if (currentTime > maxTime)
        {
            currentTime = 0;
            lastPoint = this.transform.position;
        }
        if (controller.Action3.WasPressed)
        {
            transform.position = lastPoint;
        }

    }       
}