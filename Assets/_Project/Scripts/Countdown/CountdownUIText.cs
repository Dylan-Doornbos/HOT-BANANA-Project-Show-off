using TMPro;
using UnityEngine;

public class CountdownUIText : CountdownUI
{
    [SerializeField] TextMeshProUGUI _txtTime;

    protected override void updateUI()
    {
        int minutes = Mathf.Clamp(Mathf.FloorToInt(_countdown.timeLeft / 60f), 0, 60);
        int seconds = Mathf.CeilToInt(_countdown.timeLeft % 60);
        _txtTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
