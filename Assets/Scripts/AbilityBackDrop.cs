using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityBackDrop : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer spriteRenderer; //Assign Manually!!

    public void Refresh(int lines) 
    {
        float height = 0.5f + 0.33f * lines;
        spriteRenderer.size = new Vector2(7, height);
    }
}
