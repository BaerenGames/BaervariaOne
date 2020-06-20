using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public GameObject thisRocket;
    public Rigidbody thisRocketBody;
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Object.Instantiate(explosion, thisRocketBody.position, thisRocketBody.rotation);
            Object.Destroy(thisRocket);
            AwaitAnimation(2.51f);
        }
    }

    IEnumerator AwaitAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        Object.Destroy(explosion);
    }
}
