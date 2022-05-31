using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Localized String")]
public class LocalizedString : ScriptableObject
{
    [SerializeField] private localizedString _line;

    public string line => _line.Get();
}

[Serializable]
public struct localizedString
{
    [TextArea] [SerializeField] private string _english;
    [TextArea] [SerializeField] private string _dutch;

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