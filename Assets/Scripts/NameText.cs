using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameText : MonoBehaviour
{
    public TextMeshPro myTMPro;
    public SpriteRenderer mySprite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh(float yPos) 
    {
        transform.localPosition = new Vector3(0, yPos, 0);
        myTMPro.ForceMeshUpdate();
        Vector2 size = myTMPro.GetPreferredValues();
        float width = myTMPro.textBounds.size.x + 0.23f;
        mySprite.size = new Vector2(0.7f, width);//The block is rotated sideways therefore width is height.
        Debug.Log(width);
    }

}
