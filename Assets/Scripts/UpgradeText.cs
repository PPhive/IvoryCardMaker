using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeText : MonoBehaviour
{
    public TextMeshPro TMPro;

    public void Refresh(string upgradeCost, string upgradeType)
    {
        upgradeCost = PublicMethods.instance.ReplaceIcons(upgradeCost);
        if (upgradeType == "»ìÉ«")
        {
            TMPro.text = "»ìÉ«" + upgradeCost;
        }
        else
        {
            TMPro.text = "Ìá´¿" + upgradeCost;
        }
    }
}
