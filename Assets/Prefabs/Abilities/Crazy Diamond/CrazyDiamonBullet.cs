using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyDiamonBullet : MonoBehaviour
{
    GameHelper _gameHealper;
    HealthHelper _healthHelper;
    AbilityDisplay _abilityDisplay;
    public GameObject CurrentAbilityl;
    public GameObject AbilityBulletObj;
    void Start()
    {
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        _abilityDisplay = CurrentAbilityl.GetComponent<AbilityDisplay>();
    }
    
    void Update()
    {
        _abilityDisplay = CurrentAbilityl.GetComponent<AbilityDisplay>();
        if (_abilityDisplay.KD_Image.enabled == false && _abilityDisplay.ability.TimeOfBonus == 0)
        {
            _abilityDisplay.Ability_Button.interactable = true;
            _abilityDisplay.ability.TimeOfBonus = _abilityDisplay.ability.BonusTime;
        }
        
        if (_abilityDisplay.KD_Image.enabled == true && _abilityDisplay.ability.TimeOfBonus > 0)
        {
            _abilityDisplay.Ability_Button.interactable = false;
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
            }
        }
    }

    public void CDBullet()
    {
        _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        if (_healthHelper.IS_Boss || _healthHelper.IS_Boss_Part4)
        {
            
            GameObject AbilityBulletObjTemp = Instantiate(AbilityBulletObj);
            _healthHelper.GetHit((_healthHelper.MaxHealth / 100) * 20);
            Destroy(AbilityBulletObjTemp,1f);
        }
        else
        {
            GameObject AbilityBulletObjTemp = Instantiate(AbilityBulletObj);
            _healthHelper.GetHit((_healthHelper.MaxHealth / 100) * 20);
            Destroy(AbilityBulletObjTemp,1f);
        }
    }
}
