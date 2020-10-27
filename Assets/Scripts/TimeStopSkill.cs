using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeStopSkill : MonoBehaviour
{
    GameHelper _gameHealper;
    Cooldown _Cooldown;
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
        if (TimeOfBonus == 0 && Name == "TS")
        {
            ButtonTS.interactable = true;
            TimeGo();
        }
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

