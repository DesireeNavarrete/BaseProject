using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    public Locale locale_code;
    public void test(Locale selected_locale)
    {
        locale_code = selected_locale;
        LocalizationSettings.SelectedLocale = selected_locale;
    }

    private void Update()
    {
        test(locale_code);
    }
}
