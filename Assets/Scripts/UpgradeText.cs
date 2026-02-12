using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeText : MonoBehaviour
{
    public TextMeshPro TMPro;

    public void Refresh(string upgradeCost, string upgradeType, string upgradeReward)
    {
        upgradeCost = PublicMethods.instance.ReplaceIcons(upgradeCost);
        upgradeReward = PublicMethods.instance.ReplaceIcons(upgradeReward);

        //TMPro.text = upgradeType + upgradeCost;
        TMPro.text = "Upgrade:" + upgradeCost;
        TMPro.text += "\n" + "Reward:" + upgradeReward;


        /*
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
        */
    }
}
