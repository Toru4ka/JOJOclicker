using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Skills : MonoBehaviour
{
    GameHelper _gameHealper;
    Cooldown _Cooldown;
    public Button ButtonDD;
    public Button ButtonTS;
    public float BonusTime;
    public float TimeOfBonus;
    public float cooldown = 1;
    public string Name;
    public GameObject TimeStopEffectPrefab;
    public GameObject BG;
    public Material BAWmaterial;
    public Material DS;

    void Start()
    {
        _Cooldown = GameObject.FindObjectOfType<Cooldown>();
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        cooldown = _Cooldown.cooldown;

    }

    
    public void Update()
    {
        if (_Cooldown.kdImage.enabled == false && TimeOfBonus == 0)
        {
            TimeOfBonus = BonusTime;
        }

        if (_Cooldown.kdImage.enabled == true && TimeOfBonus > 0)
        {
            if (TimeOfBonus > 0)
            {
                TimeOfBonus -= Time.deltaTime;
            }

            if (TimeOfBonus < 0.2)
            {
                TimeOfBonus = 0;
                
            }

            if (TimeOfBonus == 0)
            {
                TimeOfBonus = 0;
                Proverka();
            }           
        }

    }
    
    public void Proverka()
    {
        if (TimeOfBonus == 0)
        {
            switch (Name)
            {
                case "DD":
                    ButtonDD.interactable = true;
                    DubleDamageMinus();
                    break;
                case "TS":
                    ButtonTS.interactable = true;
                    TimeGo();
                    break;
            }
        }
    }
    public void DubleDamagePlus()
    {
        _gameHealper.PlayerDamage = _gameHealper.PlayerDamage * 2;
        ButtonDD.interactable = false;
    }
    public void DubleDamageMinus()
    {
        _gameHealper.PlayerDamage = _gameHealper.PlayerDamage / 2;
    }

    public void TimeStop()
    {
        GameObject TimeStopEffect = Instantiate(TimeStopEffectPrefab) as GameObject;
        BG.GetComponent<Renderer>().material = BAWmaterial;
        ButtonTS.interactable = false;
    }

    public void TimeGo()
    {
        BG.GetComponent<Renderer>().material = DS;

    }
}
