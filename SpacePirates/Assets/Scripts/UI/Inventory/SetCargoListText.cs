using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCargoListText : MonoBehaviour
{
    public Text nameText;

    public void SetText(string inputText)
    {
        nameText.text = inputText;
    }
}
