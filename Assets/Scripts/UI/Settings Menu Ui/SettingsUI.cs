using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsUI : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetResulation(int resulationIndex)
    {
        if (resulationIndex == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (resulationIndex == 1)
        {
            Screen.SetResolution(1280, 720, true);
        }
        else
        {
            Screen.SetResolution(640, 480, true);
        }
    }

    public void SetGraphicLv(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }

    public void MouseSens(float value)
    {
        PlayerPrefs.SetFloat("MouseSens", value);
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterAudio", Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicAudio", Mathf.Log10(value) * 20);
    }

}
