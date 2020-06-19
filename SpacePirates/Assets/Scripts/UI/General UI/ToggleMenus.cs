using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ToggleMenus : MonoBehaviour
{
    public string activeMenu = "main";
    public GameObject shipMenuUI;
    public GameObject inventoryMenuUI;
    public GameObject mainUI;

    private void Start()
    {
        shipMenuUI.SetActive(false);
        inventoryMenuUI.SetActive(false);
        mainUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (shipMenuUI.activeSelf == false)
            {
                setActiveMenu(shipMenuUI);
            }
            else
            {
                setActiveMenu(mainUI);
            }
        }
        if (Input.GetKeyDown("i"))
        {
            if (inventoryMenuUI.activeSelf == false)
            {
                setActiveMenu(inventoryMenuUI);
            }
            else
            {
                setActiveMenu(mainUI);
            }
        }
    }

    private void setActiveMenu(GameObject activeMenu)
    {
        if (activeMenu == mainUI)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            if (activeMenu == inventoryMenuUI) { inventoryMenuUI.GetComponent<UpdateUI>().UpdateThisUI(); }
            if (activeMenu == shipMenuUI) { }
        }
        
        inventoryMenuUI.SetActive(false);
        shipMenuUI.SetActive(false);
        mainUI.SetActive(false);

        activeMenu.SetActive(true);
    }
}
