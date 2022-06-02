using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocaleSelector : MonoBehaviour
{
    
    public void SetLocaleEN()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale("en");
    }

    public void SetLocaleNL()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale("nl");
    }
}