using System.Collections;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public Rigidbody player;
    public GameObject missle;
    public float cooldown = 2.5f;
    public float remainingCooldown;
    public bool missleOnCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            if (missleOnCooldown == false)
            {
                Instantiate(missle, (player.position + transform.forward * 2.5f), player.rotation * Quaternion.Euler(90, 0, 0));
                missleOnCooldown = true;
                remainingCooldown = cooldown;
            }
        }
        if (missleOnCooldown)
        {
            remainingCooldown -= Time.deltaTime;
            if (remainingCooldown <= 0)
            {
                missleOnCooldown = false;
            }
        }
    }

    public float getRemainungCooldown()
    {
        return remainingCooldown;
    }
}
