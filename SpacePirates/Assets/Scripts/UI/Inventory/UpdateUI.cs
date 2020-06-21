using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    public GameObject capacityUI;
    public GameObject cargoListUI;

    public void UpdateThisUI()
    {
        capacityUI.GetComponent<SetLoadUI>().UpdateLoadUI();
        cargoListUI.GetComponent<CargoListFill>().UpdateCargoList();
    }
}
