using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChanger : MonoBehaviour
{
    public List<Sprite> backgronds;
    public SpriteRenderer myRenderer;

    public void changeBase(int id) 
    {
        if (id >= 0 && id < backgronds.Count)
        {
            myRenderer.sprite = backgronds[id];
        }
        else 
        {
            myRenderer.sprite = backgronds[backgronds.Count - 1];
        }
    }
}
