using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShipMenu : MonoBehaviour
{
    public bool shipMenuActive = false;
    public GameObject shipMenuUI;
    public GameObject mainUI;

    private void Start()
    {
        shipMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (shipMenuActive == true)
            {
                shipMenuActive = false;
                shipMenuUI.SetActive(false);
                mainUI.SetActive(true);
                Time.timeScale = 1;
            }
            else
            {
                shipMenuActive = true;
                shipMenuUI.SetActive(true);
                mainUI.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }
}
