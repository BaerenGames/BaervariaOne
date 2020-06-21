using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUp : MonoBehaviour
{
    public GameObject nameText;
    public GameObject amountText;
    public GameObject volumeText;
    public GameObject dumpText;

    public void UpdateText(string name, string amount, string volume, int maxAmount)
    {
        nameText.GetComponent<SetCargoListText>().SetText(name);
        amountText.GetComponent<SetCargoListText>().SetText(name);
        volumeText.GetComponent<SetCargoListText>().SetText(name);
        dumpText.GetComponent<SetCargoListDump>().setMaxAmount(maxAmount);
    }
}
