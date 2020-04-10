using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WindowManager : MonoBehaviour
{

    private const string RESOLUTION_PREF_KEY = "resolution";

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private List<string> qualityNames;

    private Resolution[] resolutions;

    private int currentResolutionIndex = 0;

    public bool fullScreen = true;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);

        resolutionDropdown.options.Clear();
        for(int i = 0; i < resolutions.Length; i++)
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData() { text = resolutions[i].ToString()});
        }

        qualityDropdown.ClearOptions();
        for(int i = 0; i < qualityNames.Count; i++)
        {
            qualityDropdown.options.Add(new TMP_Dropdown.OptionData() { text = qualityNames[i]});
        }
    }

    private void Update()
    {
        
    }

    public void ApplyQuality()
    {
        for(int i = 0; i < qualityNames.Count; i++)
        {
            if(qualityDropdown.options[qualityDropdown.value].text == qualityNames[i])
            {
                QualitySettings.SetQualityLevel(i, true);
            }
        }
    }

    public void ApplyResolution()
    {
        for(int i = 0; i < resolutions.Length; i++)
        {
            if(resolutions[i].ToString() == resolutionDropdown.options[resolutionDropdown.value].text)
            {
                Screen.SetResolution(resolutions[i].width, resolutions[i].height, fullScreen);
                Debug.Log(resolutions[i].ToString());
            }
        }
    }

    public void ToggleWindow()
    {
        Screen.fullScreen = !Screen.fullScreen;
        fullScreen = Screen.fullScreen;
    }
}
