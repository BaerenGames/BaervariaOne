using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipHandler : MonoBehaviour
{
    public List<Ship> shipMasterList;

    public Ship FetchShip(string shipID)
    {
        return shipMasterList.Find(x => x.id == shipID);
    }
}