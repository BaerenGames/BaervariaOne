using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo
{
    // Name of the cargo
    public string cargoName { get; set; }
    // Volume of the cargo, used to determine the amount of space it occupies
    public float cargoVolume { get; set; }
    // Value at which the cargo gets initialized at
    public float cargoStartValue { get; set; }
    // Category of the cargo, might be used to handle different types of cargo  
    public string cargoCategory { get; set; }
    // Attributes of the cargo, might be used for special requirements or consequences for certain cargo
    public List<string> cargoAttributes { get; set; }
    // Properties of the cargo, might be used for checks concerning the cargo itself
    public List<string> cargoProperties { get; set; }

    public Cargo(string cargoNamePar,
        float cargoVolumePar,
        float cargoStartValuePar,
        string cargoCategoryPar = null,
        List<string> cargoAttributesPar = null,
        List<string> cargoPropertiesPar = null)
    {
        cargoName = cargoNamePar;
        cargoVolume = cargoVolumePar;
        cargoStartValue = cargoStartValuePar;
        cargoCategory = cargoCategoryPar;
        cargoAttributes = cargoAttributesPar;
        cargoProperties = cargoPropertiesPar;
    }
}
public class CargoHandler : MonoBehaviour
{
    private IDictionary<string, Cargo> cargoMasterList = new Dictionary<string, Cargo>();

    // Start is called before the first frame update
    void Start()
    {
        // Initiate available Cargo in game, OUTSOURCE LATER!
        cargoMasterList.Add("ration", new Cargo("Rations", 1f, 10f));
        cargoMasterList.Add("metal", new Cargo("Metal", 3f, 50f));
        cargoMasterList.Add("relic", new Cargo("Relic", 75f, 500f));
    }

    public void AddCargoType(string cargoID, Cargo cargoType)
    {
        cargoMasterList.Add(cargoID, cargoType);
    }

    public Cargo FetchCargo(string cargoID)
    {
        return cargoMasterList[cargoID];
    }
}
