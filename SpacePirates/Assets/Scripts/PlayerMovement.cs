using UnityEditor.Timeline;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public bool movement_enabled;
    public float max_speed;
    public float min_speed;
    public float min_break_speed;
    public float current_speed;
    public float base_acceleration_rate;
    public float acceleration_modifier;
    public float acceleration_modifier_rate;
    public float acceleration_modifier_max;
    public float acceleration_modifier_min;
    public float current_acceleration;
    public float speed_decay;
    public float acceleration_decay;
    public float rotation_rate;

    // Use this for initialization
    private void Start()
    {
        // Asks if the Movement itself is enabled
        movement_enabled = true;
        // Describes the maximal speed for the player
        max_speed = 40f;
        // Describes the minimal speed for the player
        min_speed = 7.5f;
        // Describes the minimal speed while breaking
        min_break_speed = 2.5f;
        // Stores the current speed of the ship, initiated as the minimum speed
        current_speed = min_speed;
        // Rate in which the player accelerates, the higher the rate, the greater the (de)acceleration
        base_acceleration_rate = 100f;
        // Modifier that is manipulated by the player, initiated at 0
        acceleration_modifier = 0f;
        // Rate at which the player can manipulate their acceleration
        acceleration_modifier_rate = 5f;
        // Maximum modifier for player acceleration
        acceleration_modifier_max = 1f;
        // Minimum modifier for player acceleration
        acceleration_modifier_min = -1f;
        // Current acceleration for the player, initated at 0
        current_acceleration = 0f;
        // Rate at which the speed of the ship decreases (up to the minimum speed), basically "friction"
        speed_decay = 1f;
        // Rate at which the acceleration decays towards 0 when not actively manipulated by the player
        acceleration_decay = 0.9f;
        // Rate at which the player can turn their ship
        rotation_rate = 45f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool breaking = false;
        if (movement_enabled == true)
        {
            // Manage Decay
            if (current_speed > min_speed)
            {
                current_speed -= speed_decay * Time.deltaTime;
                if (current_speed < min_speed)
                {
                    current_speed = min_speed;
                }
            }

            if (acceleration_modifier > 0)
            {
                acceleration_modifier -= acceleration_decay * Time.deltaTime;
                if (acceleration_modifier < 0)
                {
                    acceleration_modifier = 0;
                }
            }
            else if (acceleration_modifier < 0)
            {
                acceleration_modifier += acceleration_decay * Time.deltaTime;
                if (acceleration_modifier > 0)
                {
                    acceleration_modifier = 0;
                }
            }

            // Manipulate Acceleration
            if (Input.GetKey("w"))
            {
                if (acceleration_modifier < acceleration_modifier_max)
                {
                    acceleration_modifier += acceleration_modifier_rate * Time.deltaTime;
                    if (acceleration_modifier > acceleration_modifier_max)
                    {
                        acceleration_modifier = acceleration_modifier_max;
                    }
                }
            }

            if (Input.GetKey("s"))
            {
                breaking = true;
                if (acceleration_modifier > acceleration_modifier_min)
                {
                    acceleration_modifier -= acceleration_modifier_rate * Time.deltaTime;
                    if (acceleration_modifier < acceleration_modifier_min)
                    {
                        acceleration_modifier = acceleration_modifier_min;
                    }
                }
            }

            // Manipulate Orientation
            if (Input.GetKey("a"))
            {
                player.transform.Rotate(0, -rotation_rate * Time.deltaTime, 0);
            }

            if (Input.GetKey("d"))
            {
                player.transform.Rotate(0, rotation_rate * Time.deltaTime, 0);
            }

            // Set the current speed
            current_speed += base_acceleration_rate * acceleration_modifier * Time.deltaTime;
            if (current_speed > max_speed)
            {
                current_speed = max_speed;
            }
            else if (current_speed < min_speed)
            {
                if (breaking == false)
                {
                    current_speed = min_speed;
                }
                else
                {
                    current_speed = min_break_speed;
                }
            }

            // Move the player
            player.transform.position += transform.forward * Time.deltaTime * current_speed;
        }
    }

    // Handles the situation in which the player collides with an obstacles
    public void Bump()
    {
        // Disable the movement for the player
        movement_enabled = false;

        // Give the player backwards push, depending on their speed at the time of the collision
        float bump_multiplier = 1.5f;
        float bump_distance = (50f + (current_speed / 1.5f)) * bump_multiplier;
        player.AddForce((-1 * Vector3.forward) * bump_distance);

        // Set the players speed, acceleration and acceleration modifier to zero
        current_speed = 0f;
        current_acceleration = 0f;
        acceleration_modifier = 0f;

        // Call coroutine that waits for a period of time (depending on speed) and reactive movement
        float wait_shock = 0.75f + (current_speed * 0.075f);
        StartCoroutine(ReactivateMovement(wait_shock));
    }

    IEnumerator ReactivateMovement(float time)
    {
        // Coroutine that reactivates movement and removes pushback after given time period
        yield return new WaitForSeconds(time);
        movement_enabled = true;
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
    }
}
