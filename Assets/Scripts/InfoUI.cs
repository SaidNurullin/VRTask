using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] private string winText;
    [SerializeField] private string startText;
    [SerializeField] private TextMeshProUGUI text;
    public void SetText(bool isWin, int number)
    {
        if (isWin)
        {
            text.text = winText;
        }
        else
        {
            text.text = startText + number.ToString();
        }
    }
}
