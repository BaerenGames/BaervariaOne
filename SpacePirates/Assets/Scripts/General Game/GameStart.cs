using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player.SetActive(true);

        player.GetComponent<InventoryHandler>().UpdateCargoLimit();
        player.GetComponent<InventoryHandler>().AddCargo("fuel", 10);
        player.GetComponent<InventoryHandler>().AddCargo("common_minerals", 10);
    }
}
