using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSpeedUI : MonoBehaviour
{
    public Text uiText;
    public GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        uiText.text = player.GetComponent<PlayerMovement>().GetSpeed().ToString("F1");
    }
}
