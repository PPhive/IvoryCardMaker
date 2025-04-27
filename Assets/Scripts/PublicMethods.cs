using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicMethods : MonoBehaviour
{
    public static PublicMethods instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public string ReplaceIcons(string text)
    {
        text = text.Replace("#ºì", "<sprite=0>");
        text = text.Replace("#»Æ", "<sprite=1>");
        text = text.Replace("#À¶", "<sprite=2>");
        text = text.Replace("#°×", "<sprite=3>");
        text = text.Replace("#ºÚ", "<sprite=4>");
        text = text.Replace("#²Ê", "<sprite=5>");
        text = text.Replace("#ÂÌ", "<sprite=6>");
        text = text.Replace("#³È", "<sprite=7>");
        text = text.Replace("#×Ï", "<sprite=8>");
        return text;
    }
}
