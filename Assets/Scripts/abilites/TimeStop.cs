using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    GameHelper _gameHealper;
    HealthHelper _healthHelper;
    AbilityDisplay _abilityDisplay;
    AbilityDisplay[] _abilitesDisplays;

    public GameObject TimeStopEffectPrefab;
    public GameObject TimeStartEffectPrefab;
    public GameObject BG;
    public Material BAWmaterial;
    public Material DS;

    private Coroutine BTP;

    bool offBossTimerPause = false;


    void Start()
    {
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        _abilitesDisplays = GameObject.FindObjectsOfType<AbilityDisplay>();
        _abilityDisplay = _abilitesDisplays[1];
    }


    public void Update()
    {
        
        
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
                
                TimeGo();    
            }
        }


    }

    public void TimeStop1()
    {
        GameObject TimeStopEffect = Instantiate(TimeStopEffectPrefab) as GameObject;
        BG.GetComponent<Renderer>().material = BAWmaterial;
        _abilityDisplay.Ability_Button.interactable = false;
        Destroy(TimeStopEffect, 8);
        BTP = StartCoroutine(BossTimerPause());
        GameObject enemyStand = GameObject.FindWithTag("enemy");
        Animator enemyStandAnimator = enemyStand.GetComponent<Animator>();
        enemyStandAnimator.enabled = false;
        AudioSource enemyStandAudioSource = enemyStand.GetComponent<AudioSource>();
        enemyStandAudioSource.Stop();
    }

    public void TimeGo()
    {
        GameObject TimeStartEffect = Instantiate(TimeStartEffectPrefab) as GameObject;
        BG.GetComponent<Renderer>().material = DS;
        Destroy(TimeStartEffect, 3);
        StopCoroutine(BTP);
        GameObject enemyStand = GameObject.FindWithTag("enemy");
        Animator enemyStandAnimator = enemyStand.GetComponent<Animator>();
        enemyStandAnimator.enabled = true;
        AudioSource enemyStandAudioSource = enemyStand.GetComponent<AudioSource>();
        enemyStandAudioSource.Play();
    }
    public IEnumerator BossTimerPause()
    {
        while (_gameHealper.BossTimerTime < 18)
        {
            float tempTime = _gameHealper.BossTimerTime;
            _gameHealper.BossTimerTime += 1;
            
            if (_gameHealper.BossTimerTime < 10)
            {
                _gameHealper.BossTimerText.text = _gameHealper.BossTimerTime.ToString(tempTime.ToString("0"));
            }
            else
            {
                _gameHealper.BossTimerText.text = _gameHealper.BossTimerTime.ToString(tempTime.ToString("00"));
            }  
            yield return new WaitForSeconds(1);
        }
        _gameHealper.BossTimerTime = 15;
    }
}