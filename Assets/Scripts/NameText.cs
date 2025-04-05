using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameText : MonoBehaviour
{
    public TextMeshPro myTMPro;
    public SpriteRenderer mySprite;

    public void Refresh(string name, float yPos) 
    {
        //ChangeName
        myTMPro.name = name;

        //LocateName on top of ability0
        transform.localPosition = new Vector3(0, yPos, 0);
        myTMPro.ForceMeshUpdate();

        //Expand backdrop according to textlengh
        float width = myTMPro.textBounds.size.x + 0.23f;
        mySprite.size = new Vector2(0.7f, width);//The block is rotated sideways therefore width is height.
        Debug.Log(width);
    }

}
