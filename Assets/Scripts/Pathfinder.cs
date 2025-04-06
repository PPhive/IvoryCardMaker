using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Pathfinder : MonoBehaviour
{
    public static Pathfinder Instance;
    public Sprite defaultSprite;
    public string spritePath;

    void Awake()
    {
        Instance = this;
        spritePath = AssetDatabase.GetAssetPath(defaultSprite);
        spritePath = spritePath.Substring(0, spritePath.Length - 18);
        //Debug.Log(spritePath);
    }
}
