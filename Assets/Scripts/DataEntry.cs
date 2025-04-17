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
        if (Input.GetKeyDown(KeyCode.Space))//Manual Screenshot
        {
            string path = Application.persistentDataPath + "/screenshot" + lastIndex + ".png";
            //Debug.Log("Saved " + Application.persistentDataPath + "/screenshot" + lastIndex + ".png");
            ScreenCapture.CaptureScreenshot(path);
        }

        if (pointer < ExampleSheetLoader.Instance.sheetLength)
        {
            sheetToData();
            cardEntry.Refresh(cardEntry.currentCard);
            string path = Application.persistentDataPath + "/screenshot" + lastIndex + ".png";
            //Debug.Log("Saved " + Application.persistentDataPath + "/screenshot" + lastIndex + ".png");
            ScreenCapture.CaptureScreenshot(path);
        }
        else 
        {
            
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
            try
            {
                thisCardData.HP = int.Parse(sheetLoader.CheckTile(pointer, 2));
            }
            catch 
            {
                thisCardData.HP = 20;
                Debug.Log("invalid HP for chara" + thisCardData.index);
            }
            thisCardData.upgradeCost = sheetLoader.CheckTile(pointer, 3);
            try
            {
                thisCardData.baseID = int.Parse(sheetLoader.CheckTile(pointer, 4));
            }
            catch
            {
                thisCardData.baseID = 0;
                Debug.Log("invalid baseID for chara" + thisCardData.index);
            }

            thisCardData.authorName = sheetLoader.CheckTile(pointer, 8);
            thisCardData.upgradeType = sheetLoader.CheckTile(pointer, 9);


            //Inputs the abilites, this action also move the pointer downward so put every entry before this
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

            //Pass on the entered data
            cardEntry.currentCard = thisCardData;
        }
    }
}