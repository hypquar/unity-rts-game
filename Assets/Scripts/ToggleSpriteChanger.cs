using UnityEngine;
using UnityEngine.UI;

public class ToggleSpriteChanger : MonoBehaviour
{
    public Toggle toggle;
    public Image knobImage; 
    public Sprite spriteOn;
    public Sprite spriteOff;

    void Start()
    {
        toggle.onValueChanged.AddListener(UpdateSprite);
        UpdateSprite(toggle.isOn);
    }




    void UpdateSprite(bool isOn)
    {
        knobImage.sprite = isOn ? spriteOn : spriteOff;
    }
}