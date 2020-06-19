using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    public GameObject capacityUI;

    public void UpdateThisUI()
    {
        capacityUI.GetComponent<SetLoadUI>().UpdateLoadUI();
    }
}
