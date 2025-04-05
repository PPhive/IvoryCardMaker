using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ability : MonoBehaviour
{
    public TextMeshPro abilityName;
    public TextMeshPro abilityDescription;
    public AbilityBackDrop myBackDrop;

    string ReplaceIcons(string text) 
    {
        text = text.Replace("#��", "<sprite=0>");
        text = text.Replace("#��", "<sprite=1>");
        text = text.Replace("#��", "<sprite=2>");
        text = text.Replace("#��", "<sprite=3>");
        text = text.Replace("#��", "<sprite=4>");
        return text;
    }

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
            abilityName.text = ReplaceIcons(abilityName.text);
            abilityDescription.text = ReplaceIcons(abilityDescription.text);
            abilityDescription.ForceMeshUpdate();
            myBackDrop.Refresh(abilityDescription.textInfo.lineCount);
        }
    }
}
