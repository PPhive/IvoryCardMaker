using System.Collections;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using yutokun;

public class DataEntry : MonoBehaviour
{
    [SerializeField]
    ExampleSheetLoader sheetLoader;
    [SerializeField]
    int pointer = 0;
    public CardEntry cardEntry;

    [SerializeField]
    int lastIndex = 0;


    [SerializeField]
    CardData thisCardData;

    void Awake()
    {
        QualitySettings.vSyncCount = 0; // Turn off VSync
    }

    void Start()
    {

    }

    void Update()
    {
        if(pointer < ExampleSheetLoader.Instance.sheetLength)
        {
            sheetToData();
            cardEntry.Refresh(cardEntry.currentCard);
            string path = Application.persistentDataPath + "/screenshot" + lastIndex + ".png";
            //Debug.Log("Saved " + Application.persistentDataPath + "/screenshot" + lastIndex + ".png");
            ScreenCapture.CaptureScreenshot(path);
        }
    }

    void sheetToData() 
    {
        int pointerIndex = int.Parse(sheetLoader.CheckTile(pointer, 0));
        if (pointerIndex != thisCardData.index) 
        {
            lastIndex = pointerIndex;
            thisCardData = new CardData();
            thisCardData.index = pointerIndex;
            thisCardData.name = sheetLoader.CheckTile(pointer, 1);
            thisCardData.HP = int.Parse(sheetLoader.CheckTile(pointer, 2));
            thisCardData.upgradeCost = sheetLoader.CheckTile(pointer, 3);
            thisCardData.baseID = int.Parse(sheetLoader.CheckTile(pointer,4));

            for (int i = 0; i < 5; i++) 
            {
                int currentline = pointer + i;
                if (currentline < ExampleSheetLoader.Instance.sheetLength)
                {
                    if (thisCardData.index == int.Parse(sheetLoader.CheckTile(currentline, 0)))
                    {
                        AbilityData thisAbility = new AbilityData();
                        thisAbility.AbilityName = sheetLoader.CheckTile(currentline, 5);
                        thisAbility.AbilityName += sheetLoader.CheckTile(currentline, 7);//this puts cost right after name in game
                        thisAbility.AbilityText = sheetLoader.CheckTile(currentline, 6);
                        //Debug.Log(thisCardData.abilityDatas.Count);
                        thisCardData.abilityDatas.Add(thisAbility);
                    }
                    else
                    {
                        pointer += i;
                        i = 5;
                    }
                }
                else
                {
                    pointer += i;
                    i = 5;
                }
            }

            cardEntry.currentCard = thisCardData;
        }
    }
}