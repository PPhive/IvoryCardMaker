using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottomManager : MonoBehaviour
{
    public float gapHeight = 0.3f;
    public List<Ability> abilities;
    public NameText nameText;
    public float heightSum;


    public void Start()
    {

    }



    public void StackAbilites(string name) 
    {
        List<Ability> abilitiesFromBelow = new List<Ability>();
        for (int i = 4; i >= 0; i--) 
        {
            if (abilities[i].abilityName.text != null) 
            {
                abilitiesFromBelow.Add(abilities[i]);
            }
        }

        Debug.Log(abilitiesFromBelow.Count);

        float CurrentHeight = -4.66f - gapHeight;
        for (int i = 0; i < abilitiesFromBelow.Count; i++)
        {
            CurrentHeight += abilitiesFromBelow[i].myBackDrop.spriteRenderer.size.y + gapHeight;
            abilitiesFromBelow[i].transform.localPosition = new Vector3(0, CurrentHeight, 0);
        }

        nameText.Refresh(name, CurrentHeight + gapHeight);
    }

    public void FindHeightSum() 
    {
        heightSum = -gapHeight;
        for (int i = 0; i < abilities.Count; i++) 
        {
            if (abilities[i].abilityName.text != null) 
            {
                heightSum += abilities[i].myBackDrop.spriteRenderer.size.y + gapHeight;
            }
        }
    }

    public void Refresh(string name, List<AbilityData> abilityDatas) 
    {
        for (int i = 0; i < abilities.Count; i++) 
        {
            if (i < abilityDatas.Count)
            {
                abilities[i].Refresh(abilityDatas[i]);
            }
            else 
            {
                abilities[i].Refresh(new AbilityData());
            }
        }

        StackAbilites(name);
    }
}
