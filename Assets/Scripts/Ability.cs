using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ability : MonoBehaviour
{
    public TextMeshPro abilityName;
    public TextMeshPro abilityDescription;
    public AbilityBackDrop myBackDrop;

    public void Refresh(AbilityData myData) 
    {
        //Enter Data
        abilityName.text = myData.AbilityName;
        abilityDescription.text = myData.AbilityText;

        //If empty, shrink, else replace #ɫ with sprites, then tell backdrop to expand accordingly
        if (abilityName.text == null)
        {
            abilityDescription.text = null;
            myBackDrop.spriteRenderer.size = new Vector2(7,0);
        }
        else 
        {
            abilityName.text = PublicMethods.instance.ReplaceIcons(abilityName.text);
            abilityDescription.text = PublicMethods.instance.ReplaceIcons(abilityDescription.text);
            abilityDescription.ForceMeshUpdate();
            myBackDrop.Refresh(abilityDescription.textInfo.lineCount);
        }
    }
}
