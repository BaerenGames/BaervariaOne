using System.Collections;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public Rigidbody player;
    public GameObject missle;
    public float cooldown = 2.5f;
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
                StartCoroutine(MissleCooldown(cooldown));
            }
        }
    }

    IEnumerator MissleCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        missleOnCooldown = false;
    }
}
