using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    SMHelper sMHelper;
    test _test;
    public SaveMusicSettings svms = new SaveMusicSettings();

    void Start()
    {
        sMHelper = GameObject.FindObjectOfType<SMHelper>();
        if (PlayerPrefs.HasKey("SVMS"))
        {
            svms = JsonUtility.FromJson<SaveMusicSettings>(PlayerPrefs.GetString("SVMS"));
            sMHelper.AMIsOn = svms.AMVolume;
            sMHelper.SliderSounds.value = svms.SoundVolume;
            sMHelper.SliderMusic.value = svms.MusicVolume;
        }
        if (PlayerPrefs.HasKey("SV"))
        {
            svms = JsonUtility.FromJson<SaveMusicSettings>(PlayerPrefs.GetString("SV"));
            sMHelper.AMIsOn = svms.AMVolume;
            sMHelper.SliderSounds.value = svms.SoundVolume;
            sMHelper.SliderMusic.value = svms.MusicVolume;
        }
    }


    void Update()
    {

    }

    [Serializable]
    public class SaveMusicSettings
    {
        public bool AMVolume;
        public float SoundVolume;
        public float MusicVolume;
    }

    private void OnDisable() //Save
    {
        svms.AMVolume = sMHelper.AMIsOn;
        svms.SoundVolume = sMHelper.SliderSounds.value;
        svms.MusicVolume = sMHelper.SliderMusic.value;
        PlayerPrefs.SetString("SVMS", JsonUtility.ToJson(svms));
    }
    private void OnApplicationQuit() //Save
    {
        svms.AMVolume = sMHelper.AMIsOn;
        svms.SoundVolume = sMHelper.SliderSounds.value;
        svms.MusicVolume = sMHelper.SliderMusic.value;
        PlayerPrefs.SetString("SVMS", JsonUtility.ToJson(svms));
    }

}
