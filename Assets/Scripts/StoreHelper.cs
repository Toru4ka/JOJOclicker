using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StoreHelper : MonoBehaviour
{
    public bool netydarov { get; set; }
    public GameObject Buttun1;
    public GameObject Buttun2;

    public GameObject miniMenu;
    public GameObject ButtonUpgrades;
    public GameObject ButtonSkins;
    
    public GameObject UpgradesContent;
    public GameObject SkinsContent;

    public GameObject panelStatistic;
    public GameObject PanelStore;
    public GameObject ButtonSettings;
    public GameObject ButtonSettingInSettings;
    public GameObject ActionBar;
    public GameObject optionpanel;
    public GameObject ButtonArowSettings;

    public GameObject BG;
    
    public void Start()
    {
        BG.SetActive(false);
    }
    public void _ButtonStorePlus()
    {
        PanelStore.SetActive(true);
        UpgradesContent.SetActive(false);
        SkinsContent.SetActive(false);
        miniMenu.SetActive(true);
        netydarov = true;
        Buttun1.SetActive(false);
        Buttun2.SetActive(true);
        ActionBar.SetActive(false);
        panelStatistic.SetActive(false);
    }

    public void _ButtonStoreMinus()
    {
        PanelStore.SetActive(false);
        netydarov = false;
        Buttun2.SetActive(false);
        Buttun1.SetActive(true);
        ActionBar.SetActive(true);
        panelStatistic.SetActive(false);
    }

    public void PauseOn()
    {
        Buttun1.SetActive(false);
        ButtonSettings.SetActive(true);
        ActionBar.SetActive(false);
        ButtonSettingInSettings.SetActive(true);
        netydarov = true; 
    }

    public void _continue()
    {
        Buttun1.SetActive(true);
        ButtonSettings.SetActive(false);
        ActionBar.SetActive(true);
        ButtonSettingInSettings.SetActive(false);
        netydarov = false;
    }
    public void gotomenu()
    {
        //SceneManager.LoadScene("Loading");
        BG.SetActive(true);
    }

    public void _ButtonSettingInSettings()
    {     
        ButtonSettingInSettings.SetActive(!ButtonSettingInSettings.activeSelf);    
    }

    public void _ActiveOptionPanel()
    {
        optionpanel.SetActive(!optionpanel.activeSelf);
    }

    public void ButtonUpgradesClick()
    {
        UpgradesContent.SetActive(true);
        miniMenu.SetActive(false);
    }

    public void ButtonSkinsClick()
    {
        SkinsContent.SetActive(true);
        miniMenu.SetActive(false);
    }

    public void ButtonStatistics()
    {
        panelStatistic.SetActive(true);
        miniMenu.SetActive(false);
    }
}
