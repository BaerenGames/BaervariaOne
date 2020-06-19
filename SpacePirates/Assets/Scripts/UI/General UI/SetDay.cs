using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDay : MonoBehaviour
{
    public Text uiText;
    public GameObject gameHandler;

    // Update is called once per frame
    void Update()
    {
        uiText.text = gameHandler.GetComponent<IngameTime>().getTime().ToString();
    }
}
