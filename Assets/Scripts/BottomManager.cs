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
        if (abilities != null) 
        {
            foreach (Ability ability in abilities) 
            {
                ability.Refresh();
            }
        }

        StackAbilites();
    }



    public void StackAbilites() 
    {
        List<Ability> abilitiesFromBelow = new List<Ability>();
        for (int i = 4; i >= 0; i--) 
        {
            if (abilities[i].abilityName.text != "") 
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

        nameText.Refresh(CurrentHeight + gapHeight);
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
}
