using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    [SerializeField] Clock _clock;
    [SerializeField] TextMeshProUGUI _txtTime;

    private void Awake()
    {
        _clock.onTimeChanged.AddListener(updateUI);
    }

    private void updateUI()
    {
        _txtTime.text = string.Format("{0:00}:{1:00}", _clock.hours, _clock.minutes);
    }
}
