using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoDumpAmountButton : MonoBehaviour
{
    public GameObject amountText;
    public int amount;

    public void OnButtonPress()
    {
        amountText.GetComponent<SetCargoListDump>().changeAmount(amount);
    }
}
