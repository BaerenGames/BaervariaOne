using System.Collections;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public Rigidbody rocket;
    public GameObject thisRocket;
    public float speed;
    public float waitPeriod;
    public float flightTime;

    // Start is called before the first frame update
    private void Start()
    {
        waitPeriod = 0.5f;
        flightTime = 0f;
        speed = 3.5f;
        StartCoroutine(IncreaseSpeed(waitPeriod));
    }


    private void FixedUpdate()
    {
        rocket.transform.position += transform.up * speed * Time.deltaTime;
        flightTime += transform.up.magnitude * speed * Time.deltaTime;
        if (flightTime >= 500)
        {
            Destroy(thisRocket);
        }

    }

    IEnumerator IncreaseSpeed(float time)
    {
        // Coroutine that reactivates movement and removes pushback after given time period
        yield return new WaitForSeconds(time);
        speed += 25f;
    }
}
