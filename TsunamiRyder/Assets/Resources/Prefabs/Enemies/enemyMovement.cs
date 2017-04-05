using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {
    public float leftBoundy = 1f;
    public float rightBoundy = 3f;

    void Update () {

        float randY = Random.Range(leftBoundy, rightBoundy);

        transform.Translate(0, rightBoundy *Time.deltaTime, 0);

    }
}
