using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeText : MonoBehaviour
{
    public TextMeshPro TMPro;
    string ReplaceIcons(string text)
    {
        text = text.Replace("#ºì", "<sprite=0>");
        text = text.Replace("#»Æ", "<sprite=1>");
        text = text.Replace("#À¶", "<sprite=2>");
        text = text.Replace("#°×", "<sprite=3>");
        text = text.Replace("#ºÚ", "<sprite=4>");
        return text;
    }

    public void Refresh(string upgradeCost, string upgradeType)
    {
        upgradeCost = ReplaceIcons(upgradeCost);
        if (upgradeType == "»ìÉ«")
        {
            TMPro.text = "»ìÉ«£º" + upgradeCost;
        }
        else
        {
            TMPro.text = "Ìá´¿£º" + upgradeCost;
        }
    }
}
