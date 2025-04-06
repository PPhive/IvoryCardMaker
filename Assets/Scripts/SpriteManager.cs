using UnityEngine;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{
    private Dictionary<string, Sprite> spriteDictionary;
    public Sprite defaultSprite;
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        LoadSprites();
    }

    public void ShowCharSprite(int id) 
    {
        spriteRenderer.sprite = GetSpriteByID(id);
    }

    private void LoadSprites()
    {
        spriteDictionary = new Dictionary<string, Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/CharacterArts");
        foreach (Sprite sprite in sprites)
        {
            string spriteID = sprite.name.Substring(0, 4); // Assumes the ID is the first 4 characters
            if (!spriteDictionary.ContainsKey(spriteID))
            {
                spriteDictionary.Add(spriteID, sprite);
            }
            else
            {
                Debug.LogWarning($"Duplicate sprite ID detected: {spriteID}. Only the first occurrence will be used.");
            }
        }
    }

    Sprite GetSpriteByID(int id)
    {
        string idString = id.ToString("D4"); // Formats the integer as a 4-digit string
        if (spriteDictionary.TryGetValue(idString, out Sprite sprite))
        {
            Debug.Log(idString);
            return sprite;
        }
        else
        {
            Debug.LogWarning($"Sprite with ID {idString} not found.");
            return null;
        }
    }
}
