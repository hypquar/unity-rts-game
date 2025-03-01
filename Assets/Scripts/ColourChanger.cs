using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourChanger : MonoBehaviour
{
    [SerializeField] private List<Color> colors = new List<Color> { Color.red, Color.green, Color.blue, Color.gray, Color.cyan, Color.magenta };
    [SerializeField] private List<Color> selectedColors;

    public void ChangeColor()
    {
        Color currentColor = gameObject.GetComponent<Image>().color;

        foreach (Color color in colors)
        {
            if (!selectedColors.Contains(color))
            {
                if (selectedColors.Contains(currentColor))
                {
                    selectedColors.Remove(currentColor);
                }

                gameObject.GetComponent<Image>().color = color;
                
                selectedColors.Add(color);
                return;
            }
        }
    }
}
