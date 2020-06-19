using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    // The name of the ship
    public string shipName { get; set; }
    // The maximum cargo capacity
    public int shipCargoCapacity { get; set; }
    // The top speed of the ship
    public float shipTopSpeed { get; set; }
    // The minimum speed of the ship
    public float shipMinSpeed { get; set; }
    // The turnrate of the ship
    public float shipTurnRate { get; set; }

    public Ship(string shipNamePar,
        int shipCargoCapacityPar = 100,
        float shipTopSpeedPar = 40f,
        float shipMinSpeedPar = 5f,
        float shipTurnRatePar = 45f)
    {
        shipName = shipNamePar;
        shipCargoCapacity = shipCargoCapacityPar;
        shipTopSpeed = shipTopSpeedPar;
        shipMinSpeed = shipMinSpeedPar;
        shipTurnRate = shipTurnRatePar;
    }

}
public class ShipHandler : MonoBehaviour
{
    private IDictionary<string, Ship> shipMasterList;

    // Start is called before the first frame update
    void Start()
    {
        // Initiate available Cargo in game, OUTSOURCE LATER!
        shipMasterList = new Dictionary<string, Ship>();
        shipMasterList.Add("startingShip", new Ship("The old reliable"));
    }

    public void AddShipType(string shipID, Ship shipType)
    {
        shipMasterList.Add(shipID, shipType);
    }

    public Ship FetchShip(string shipID)
    {
        return shipMasterList[shipID];
    }
}
