using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLoadUI : MonoBehaviour
{
    public GameObject player;
    public Text uiText;

    public void UpdateLoadUI()
    {
        float currentLoad = player.GetComponent<InventoryHandler>().GetCurrentLoad();
        int maxLoad = player.GetComponent<InventoryHandler>().cargoLimit;
        string loadString = currentLoad.ToString("F1") + "/" + maxLoad.ToString();
        uiText.text = loadString;
    }
}
