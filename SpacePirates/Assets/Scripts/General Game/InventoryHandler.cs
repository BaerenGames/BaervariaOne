using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEntry : MonoBehaviour
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
    public GameObject playerShip;
    public GameObject cargoMasterList;
    public List<InventoryEntry> playerInventory;
    public int cargoLimit = 0;

    void Start()
    {
        cargoLimit = playerShip.GetComponent<ShipHandler>().FetchShip("startingShip").shipCargoCapacity;
        Cargo startingRations = cargoMasterList.GetComponent<CargoHandler>().FetchCargo("ration");
        InventoryEntry startingRationsEntry = new InventoryEntry(startingRations, 10);
        playerInventory.Add(startingRationsEntry);
    }

    public bool AddCargo(Cargo cargoToAdd, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }
        else
        {
            if (GetCurrentLoad() > cargoLimit)
            {
                return false;
            }
            else
            {
                InventoryEntry addedCargo = new InventoryEntry(cargoToAdd, amount);
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
            currentLoad += entry.cargoType.cargoVolume * entry.cargoAmount;
        }
        return currentLoad;
    }
}
