using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameTime : MonoBehaviour
{
    public int day = 0;

    public void advanceTime(int amount)
    {
        day += amount;
    }

    public int getTime()
    {
        return day;
    }
}
