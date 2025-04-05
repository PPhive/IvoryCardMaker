using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeText : MonoBehaviour
{
    public TextMeshPro TMPro;
    string ReplaceIcons(string text)
    {
        text = text.Replace("#��", "<sprite=0>");
        text = text.Replace("#��", "<sprite=1>");
        text = text.Replace("#��", "<sprite=2>");
        text = text.Replace("#��", "<sprite=3>");
        text = text.Replace("#��", "<sprite=4>");
        return text;
    }

    public void Refresh(string upgradeCost)
    {
        upgradeCost = ReplaceIcons(upgradeCost);
        TMPro.text = "����" + upgradeCost;
    }
}
