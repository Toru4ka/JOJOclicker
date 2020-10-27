using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SMHelper : MonoBehaviour
{

    public AudioMixer MasterMixer;
    public Slider SliderMusic;
    public Slider SliderSounds;
    public Sprite AMOn;
    public Sprite AMOff;
    public Image Mute;
    public bool AMIsOn = true;
    public GameObject PanelSettings;
    

    public void Start()
    {
        if (AMIsOn == false)
        {
            Mute.sprite = AMOff;
            AudioListener.volume = 0;
        }
        else if (AMIsOn == true)
        {
            Mute.sprite = AMOn;
            AudioListener.volume = 1;
        }
    }
    private void Update()
    {
        SetSoundLvl(SliderSounds.value);
        SetMusicLvl(SliderMusic.value);
        if (AMIsOn == false)
        {
            Mute.sprite = AMOff;
            AudioListener.volume = 0;
        }
        else if (AMIsOn == true)
        {
            Mute.sprite = AMOn;
            AudioListener.volume = 1;
        }
    }

    public void SetSoundLvl(float soundLvl)
    {
        MasterMixer.SetFloat("SoundsGame", soundLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        MasterMixer.SetFloat("MusicGame", musicLvl);
    }

    public void MasterMixerOff()
    {
        if (AMIsOn == true)
        {
            AudioListener.volume = 0;
            AMIsOn = false;
        }
        else if (AMIsOn == false)
        {
            AudioListener.volume = 1;
            AMIsOn = true;
        }
    }

    public void clousePanelSettings()
    {
        PanelSettings.SetActive(false);
    }
}
