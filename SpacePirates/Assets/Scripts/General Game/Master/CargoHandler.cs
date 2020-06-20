using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoHandler : MonoBehaviour
{
    public List<Cargo> cargoMasterList;

    public Cargo FetchCargo(string cargoID)
    {
        return cargoMasterList.Find(x => x.id == cargoID);
    }
}
