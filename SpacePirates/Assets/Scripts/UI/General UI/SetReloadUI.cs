using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetReloadUI : MonoBehaviour
{
    public GameObject player;
    public Text uiText;
    public bool ready = true;
    public float timer = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float remainingCooldown = player.GetComponent<FireWeapon>().getRemainungCooldown();
        if (remainingCooldown <= 0)
        {
            uiText.text = "READY";
        }
        else
        {
            uiText.text = remainingCooldown.ToString("F1") + "s";
        }
    }
}
