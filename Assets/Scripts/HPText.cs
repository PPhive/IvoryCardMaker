using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HPText : MonoBehaviour
{
    public TextMeshPro TMPro;

    public void Refresh(int hp) 
    {
        TMPro.text = "HP " + hp;
    }
}
