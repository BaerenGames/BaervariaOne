using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoListFill : MonoBehaviour
{
    public GameObject playerInventory;
    public GameObject anchor;
    public GameObject cargoListEntry;

    public void UpdateCargoList()
    {
        foreach (Transform child in anchor.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (InventoryEntry cargoItem in playerInventory.GetComponent<InventoryHandler>().GetCurrentInventory())
        {
            GameObject newEntry = Instantiate(cargoListEntry);
            newEntry.SetActive(true);
            string entryText = cargoItem.cargoType.name;
            int entryMaxAmount = cargoItem.cargoAmount;
            string entryAmount = entryMaxAmount.ToString();
            string entryVolume = (cargoItem.cargoType.volume * entryMaxAmount).ToString();
            newEntry.GetComponent<SetUp>().UpdateText(entryText,
                entryAmount,
                entryVolume,
                entryMaxAmount);
            newEntry.transform.SetParent(anchor.transform, false);
        }
    }
}
