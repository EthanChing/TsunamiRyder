using UnityEngine;
using System.Collections;

public class CoroutineSlowTime : MonoBehaviour {

    public float slowness = 10f;
    public float timeStamp = 0f;
    public float cooldownPeriodInSeconds = 3f;
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (timeStamp <= Time.time) {
            if (coll.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                StartCoroutine(slow());
                timeStamp = Time.time + cooldownPeriodInSeconds;
            } }
    }
    
    IEnumerator slow ()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f / slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        
    }
}
