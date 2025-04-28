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
        if (upgradeType == "混色")
        {
            TMPro.text = "混色" + upgradeCost;
        }
        else if (upgradeType == "中和")
        {
            TMPro.text = "中和" + upgradeCost;
        }
        else
        {
            TMPro.text = "提纯" + upgradeCost;
        }
    }
}
