using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InventoryEntry
{
    public Cargo cargoType { get; set; }
    public int cargoAmount { get; set; }

    public InventoryEntry(Cargo typePar, int amountPar)
    {
        cargoType = typePar;
        cargoAmount = amountPar;
    }
}

public class InventoryHandler : MonoBehaviour
{
    public Ship playerShip;
    public GameObject cargoMasterList;
    private List<InventoryEntry> playerInventory = new List<InventoryEntry>();
    public int cargoLimit = 0;

    public bool AddCargo(string cargoToAddID, int amount)
    {
        Cargo cargoToAdd = cargoMasterList.GetComponent<CargoHandler>().FetchCargo(cargoToAddID);
        if (amount <= 0 || cargoToAdd == null)
        {
            return false;
        }
        else
        {
            Debug.Log("Made it to else");
            if (GetCurrentLoad() > cargoLimit)
            {
                Debug.Log("Over Limit");
                return false;
            }
            else
            {
                InventoryEntry addedCargo = new InventoryEntry(cargoToAdd, amount);
                playerInventory.Add(addedCargo);
                return true;
            }
        }
    }

    public bool SubtractCargo(Cargo cargoToSub, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }
        else
        {
            int cargoEntry = playerInventory.FindIndex(entry => entry.cargoType == cargoToSub);
            if (cargoEntry == -1)
            {
                return false;
            }
            else
            {
                if (playerInventory[cargoEntry].cargoAmount >= amount)
                {
                    playerInventory[cargoEntry].cargoAmount -= amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public float GetCurrentLoad()
    {
        float currentLoad = 0f;
        foreach (InventoryEntry entry in playerInventory)
        {
            currentLoad += entry.cargoType.volume * entry.cargoAmount;
        }
        return currentLoad;
    }
    
    public void UpdateCargoLimit()
    {
        cargoLimit = playerShip.cargoCapacity;
    }
}
