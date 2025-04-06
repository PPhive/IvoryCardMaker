using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEntry : MonoBehaviour
{
    public BottomManager bottomText;
    public HPText hpText;
    public UpgradeText upgradeText;
    public BaseChanger baseChanger;
    public SpriteManager spriteManager;

    [SerializeField]
    public CardData currentCard;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void Refresh(CardData cardData) 
    {
        hpText.Refresh(cardData.HP);
        upgradeText.Refresh(cardData.upgradeCost);
        bottomText.Refresh(cardData.name, cardData.abilityDatas);
        baseChanger.changeBase(cardData.baseID);
        spriteManager.ShowCharSprite(cardData.index);
    }
}

[System.Serializable]
public class CardData
{
    public int index;
    public string name;
    public int HP;
    public string upgradeCost;
    public int baseID;
    public List<AbilityData> abilityDatas = new List<AbilityData>();

    public void Clear() 
    {
        index = 0;
        name = null;
        HP = 0;
        upgradeCost = null;
        baseID = 8;//white
        abilityDatas.Clear();
    }
}

[System.Serializable]
public class AbilityData 
{
    public string AbilityName;
    public string AbilityText;
}
