using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC : MonoBehaviour
{
    GameHelper _gameHealper;
    Cooldown _Cooldown;
    public float cooldownTime = 2;
    public float nextFireTime = 0;
    public bool down;
    public string Name;
    public float BonusTime;
    public GameObject TimeStopEffectPrefab;
    public GameObject BG;
    public Material BAWmaterial;
    public Material DS;
    void Start()
    {
        down = Input.GetButtonDown(this.ToString());
        _Cooldown = GameObject.FindObjectOfType<Cooldown>();
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
    }
    void Update()
    {
        if (_Cooldown.kdImage.enabled == true && BonusTime > 0)
        {
            if (BonusTime > 0)
            {
                BonusTime -= Time.deltaTime;
            }
        }

        if (Time.time > nextFireTime)
        {

            if (down == true)
            {
                switch (Name)
                {
                    case "DD":
                        DubleDamagePlus();
                        break;
                    case "TS":
                        TimeStop();
                        break;
                }
            }

        }


    }

    public void DubleDamagePlus()
    {
        _gameHealper.PlayerDamage = _gameHealper.PlayerDamage * 2;
    }
    public void DubleDamageMinus()
    {
        _gameHealper.PlayerDamage = _gameHealper.PlayerDamage / 2;
    }

    public void TimeStop()
    {
        GameObject TimeStopEffect = Instantiate(TimeStopEffectPrefab) as GameObject;
        BG.GetComponent<Renderer>().material = BAWmaterial;

    }

    public void TimeGo()
    {
        BG.GetComponent<Renderer>().material = DS;

    }
}
