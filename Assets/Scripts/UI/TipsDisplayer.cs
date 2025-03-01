using TMPro;
using UnityEngine;

public class TipsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tipText;

    public void DisplayTip(string tip)
    {
        tipText.text = tip;
    }

    public void ClearTip()
    {
        tipText.text = string.Empty;
    }
}
