using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelper : MonoBehaviour {
    
    public GameObject PanelSettings;
    public GameObject PanelAbout;


    public void clousePanelSettings()
    {
        PanelSettings.SetActive(false);
    }

    public void openPanelSettings()
    {
        PanelSettings.SetActive(true);
    }

    public void clousePanelAbout()
    {
        PanelAbout.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void OpenClouse(GameObject Panel)
    {
        if(Panel.activeSelf == false)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }

    public void GoByURL(string urladdress)
    {
        Application.OpenURL(urladdress);
    }

    

}
