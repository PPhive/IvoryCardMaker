using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ability : MonoBehaviour
{
    public TextMeshPro abilityName;
    public TextMeshPro abilityDescription;
    public AbilityBackDrop myBackDrop;

    void Start()
    {

    }

    string ReplaceIcons(string text) 
    {
        text = text.Replace("#ºì", "<sprite=0>");
        text = text.Replace("#»Æ", "<sprite=1>");
        text = text.Replace("#À¶", "<sprite=2>");
        text = text.Replace("#°×", "<sprite=3>");
        text = text.Replace("#ºÚ", "<sprite=4>");
        return text;
    }

    public void Refresh() 
    {
        if (abilityName.text == "")
        {
            abilityDescription.text = "";
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
