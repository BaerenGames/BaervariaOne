using UnityEditor.Timeline;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public bool movementEnabled;
    public float maxSpeed;
    public float minSpeed;
    public float minBreakSpeed;
    public float currentSpeed;
    public float baseAccelerationRate;
    public float accelerationModifier;
    public float accelerationModifierRate;
    public float accelerationModifierMax;
    public float accelerationModifierMin;
    public float currentAcceleration;
    public float speedDecay;
    public float accelerationDecay;
    public float rotationRate;

    // Use this for initialization
    private void Start()
    {
        // Asks if the Movement itself is enabled
        movementEnabled = true;
        // Describes the maximal speed for the player
        maxSpeed = 40f;
        // Describes the minimal speed for the player
        minSpeed = 7.5f;
        // Describes the minimal speed while breaking
        minBreakSpeed = 2.5f;
        // Stores the current speed of the ship, initiated as the minimum speed
        currentSpeed = minSpeed;
        // Rate in which the player accelerates, the higher the rate, the greater the (de)acceleration
        baseAccelerationRate = 100f;
        // Modifier that is manipulated by the player, initiated at 0
        accelerationModifier = 0f;
        // Rate at which the player can manipulate their acceleration
        accelerationModifierRate = 5f;
        // Maximum modifier for player acceleration
        accelerationModifierMax = 1f;
        // Minimum modifier for player acceleration
        accelerationModifierMin = -1f;
        // Current acceleration for the player, initated at 0
        currentAcceleration = 0f;
        // Rate at which the speed of the ship decreases (up to the minimum speed), basically "friction"
        speedDecay = 1f;
        // Rate at which the acceleration decays towards 0 when not actively manipulated by the player
        accelerationDecay = 0.9f;
        // Rate at which the player can turn their ship
        rotationRate = 45f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool breaking = false;
        if (movementEnabled == true)
        {
            // Manage Decay
            if (currentSpeed > minSpeed)
            {
                currentSpeed -= speedDecay * Time.deltaTime;
                if (currentSpeed < minSpeed)
                {
                    currentSpeed = minSpeed;
                }
            }

            if (accelerationModifier > 0)
            {
                accelerationModifier -= accelerationDecay * Time.deltaTime;
                if (accelerationModifier < 0)
                {
                    accelerationModifier = 0;
                }
            }
            else if (accelerationModifier < 0)
            {
                accelerationModifier += accelerationDecay * Time.deltaTime;
                if (accelerationModifier > 0)
                {
                    accelerationModifier = 0;
                }
            }

            // Manipulate Acceleration
            if (Input.GetKey("w"))
            {
                if (accelerationModifier < accelerationModifierMax)
                {
                    accelerationModifier += accelerationModifierRate * Time.deltaTime;
                    if (accelerationModifier > accelerationModifierMax)
                    {
                        accelerationModifier = accelerationModifierMax;
                    }
                }
            }

            if (Input.GetKey("s"))
            {
                breaking = true;
                if (accelerationModifier > accelerationModifierMin)
                {
                    accelerationModifier -= accelerationModifierRate * Time.deltaTime;
                    if (accelerationModifier < accelerationModifierMin)
                    {
                        accelerationModifier = accelerationModifierMin;
                    }
                }
            }

            // Manipulate Orientation
            if (Input.GetKey("a"))
            {
                player.transform.Rotate(0, -rotationRate * Time.deltaTime, 0);
            }

            if (Input.GetKey("d"))
            {
                player.transform.Rotate(0, rotationRate * Time.deltaTime, 0);
            }

            // Set the current speed
            currentSpeed += baseAccelerationRate * accelerationModifier * Time.deltaTime;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
            else if (currentSpeed < minSpeed)
            {
                if (breaking == false)
                {
                    currentSpeed = minSpeed;
                }
                else
                {
                    currentSpeed = minBreakSpeed;
                }
            }

            // Move the player
            player.transform.position += transform.forward * Time.deltaTime * currentSpeed;
        }
    }

    // Handles the situation in which the player collides with an obstacles
    public void Bump()
    {
        // Disable the movement for the player
        movementEnabled = false;

        // Give the player backwards push, depending on their speed at the time of the collision
        float bump_multiplier = 1.5f;
        float bump_distance = (50f + (currentSpeed / 1.5f)) * bump_multiplier;
        player.AddForce((-1 * Vector3.forward) * bump_distance);

        // Set the players speed, acceleration and acceleration modifier to zero
        currentSpeed = 0f;
        currentAcceleration = 0f;
        accelerationModifier = 0f;

        // Call coroutine that waits for a period of time (depending on speed) and reactive movement
        float wait_shock = 0.75f + (currentSpeed * 0.075f);
        StartCoroutine(ReactivateMovement(wait_shock));
    }

    IEnumerator ReactivateMovement(float time)
    {
        // Coroutine that reactivates movement and removes pushback after given time period
        yield return new WaitForSeconds(time);
        movementEnabled = true;
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
    }

    public float GetSpeed()
    {
        return currentSpeed;
    }
}
