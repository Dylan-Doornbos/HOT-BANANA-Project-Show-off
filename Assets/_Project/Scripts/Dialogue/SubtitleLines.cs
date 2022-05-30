using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Subtitle Lines")]
public class SubtitleLines : ScriptableObject
{
    [SerializeField] private localizedString[] _lines;

    public string GetLine(int pIndex)
    {
        if (pIndex > 0 || pIndex < _lines.Length)
        {
            return _lines[pIndex].Get();
        }

        return "Invalid line";
    }
}

[Serializable]
struct localizedString
{
    [SerializeField] private string _english;
    [SerializeField] private string _dutch;

    public string Get()
    {
        if (!PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.SetInt("language", 0);
        }
        
        switch (PlayerPrefs.GetInt("language"))
        {
            case 0: return _english;
            case 1: return _dutch;
        }

        return "Invalid language index.";
    }
}