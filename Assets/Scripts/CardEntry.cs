using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEntry : MonoBehaviour
{
    public BottomManager bottomText;
    public HPText hpText;
    public UpgradeText upgradeText;
    [SerializeField]
    public CardData currentCard;

    void Start()
    {
        Refresh(currentCard);
    }

    void Update()
    {
        
    }

    void Refresh(CardData cardData) 
    {
        hpText.Refresh(cardData.HP);
        upgradeText.Refresh(cardData.upgradeCost);
        bottomText.Refresh(cardData.name, cardData.abilityDatas);
    }
}

[System.Serializable]
public class CardData
{
    public string name;
    public int HP;
    public string upgradeCost;
    public Sprite sprite;
    public List<AbilityData> abilityDatas;

    public void Clear() 
    {
        name = null;
        HP = 0;
        upgradeCost = null;
        sprite = null;
        abilityDatas.Clear();
    }
}

[System.Serializable]
public class AbilityData 
{
    public string AbilityName;
    public string AbilityText;
}
