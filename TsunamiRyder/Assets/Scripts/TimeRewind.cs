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
    public float timeStamp = 0f;
    public float cooldownPeriodInSeconds = 5f;

    void Update()

    {

        controller = InputManager.Devices[playerNum];
        currentTime += Time.deltaTime;
        if (currentTime > maxTime)
        {
            currentTime = 0;
            lastPoint = this.transform.position;
        }
        if (timeStamp <= Time.time)
        {
            if (controller.Action3.WasPressed)
            {
                transform.position = lastPoint;
                timeStamp = Time.time + cooldownPeriodInSeconds;
            }
        }
    }       
}