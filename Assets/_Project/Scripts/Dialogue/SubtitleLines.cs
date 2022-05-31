using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Subtitle Lines")]
public class SubtitleLines : ScriptableObject
{
    [SerializeField] private LocalizedString[] _lines;

    public string GetLine(int pIndex)
    {
        if (pIndex > 0 || pIndex < _lines.Length)
        {
            return _lines[pIndex].GetLocalizedString();
        }

        return "Invalid line";
    }
}