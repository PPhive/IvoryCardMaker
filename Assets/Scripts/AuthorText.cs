using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AuthorText : MonoBehaviour
{
    public TextMeshPro myTMPro;

    public void Refresh(string name)
    {
        if (name != null && name != "")
        {
            myTMPro.text = "OC×÷Õß:" + name;
        }
        else 
        {
            myTMPro.text = "";
        }

        myTMPro.ForceMeshUpdate();
    }
}
