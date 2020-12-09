using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD : MonoBehaviour
{
    GameHelper _gameHealper;
    AbilityDisplay _abilityDisplay;
    AbilityDisplay[] _abilitesDisplays;


    void Start()
    {
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        GameObject GM = GameObject.FindGameObjectWithTag("double damage");
        _abilityDisplay = GM.GetComponent<AbilityDisplay>();
        //_abilitesDisplays = GameObject.FindObjectsOfType<AbilityDisplay>();
        //_abilityDisplay = _abilitesDisplays[0];
    }


    public void Update()
    {
        //_abilityDisplay = GameObject.FindObjectOfType<AbilityDisplay>();
        GameObject GM = GameObject.FindGameObjectWithTag("double damage");
        _abilityDisplay = GM.GetComponent<AbilityDisplay>();
        if (_abilityDisplay.KD_Image.enabled == false && _abilityDisplay.ability.TimeOfBonus == 0)
        {
            _abilityDisplay.Ability_Button.interactable = true;
            _abilityDisplay.ability.TimeOfBonus = _abilityDisplay.ability.BonusTime;
        }

        if (_abilityDisplay.KD_Image.enabled == true && _abilityDisplay.ability.TimeOfBonus > 0)
        {
            if (_abilityDisplay.ability.TimeOfBonus > 0)
            {
                _abilityDisplay.ability.TimeOfBonus -= Time.deltaTime;
            }

            if (_abilityDisplay.ability.TimeOfBonus < 0.2)
            {
                _abilityDisplay.ability.TimeOfBonus = 0;

            }

            if (_abilityDisplay.ability.TimeOfBonus == 0)
            {
                _abilityDisplay.ability.TimeOfBonus = 0;
                DubleDamageMinus();
            }
        }
    }
    public void DubleDamagePlus()
    {
        _gameHealper.PlayerDamage = _gameHealper.PlayerDamage * 2;
        _abilityDisplay.Ability_Button.interactable = false;
    }
    public void DubleDamageMinus()
    {

        _gameHealper.PlayerDamage = _gameHealper.PlayerDamage / 2;
    }
}