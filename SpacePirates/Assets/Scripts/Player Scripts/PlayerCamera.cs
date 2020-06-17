using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Controlls the camera movements in respect to the player position
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position + offset;
    }
}
