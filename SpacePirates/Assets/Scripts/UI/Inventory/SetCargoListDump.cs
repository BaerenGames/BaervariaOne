using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCargoListDump : MonoBehaviour
{
    public Text cargoDump;
    public int dumpAmount = 0;
    public int maxAmount = 100;

    public void changeAmount(int amount)
    {
        if (amount < 0)
        {
            if (dumpAmount < Mathf.Abs(amount))
            {
                dumpAmount = 0;
            }
            else
            {
                dumpAmount += amount;
            }
        }
        else if (dumpAmount + amount > maxAmount)
        {
            dumpAmount = maxAmount;
        }
        else
        {
            dumpAmount += amount;
        }
        cargoDump.text = dumpAmount.ToString();
    }

    public void setMaxAmount(int maxAmountPar)
    {
        maxAmount = maxAmountPar;
    }
}
