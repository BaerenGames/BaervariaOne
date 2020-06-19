using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        player.SetActive(true);
    }
}
