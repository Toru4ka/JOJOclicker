using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthHelper : MonoBehaviour
{
    public int CoinChanse;
    public int MaxHealth = 100;
    public int Health = 100;
    public int BEP = 90;
    public bool IS_Boss;
    bool _isdead;
    bool once = false;
    GameHelper _gameHealper;
    public GameObject DeathEffect;
    bool oncefortimer = false;

    void Start()
    {
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        int count = _gameHealper._count;
        MaxHealth = System.Convert.ToInt32(MaxHealth * (count * 0.55));
        Health = System.Convert.ToInt32(Health * (count * 0.55));
        _gameHealper.HealthSlider.maxValue = MaxHealth;
        _gameHealper.HealthSlider.value = MaxHealth;
    }

    void Update()
    {
        if (!oncefortimer && IS_Boss)
        {
            StartCoroutine(BossTimerEnumerator());
        }
        if (!once && IS_Boss && Health != MaxHealth)
        {
            StartCoroutine(Stage1());
        }
        _gameHealper.HealthSlider.value = Health;
    }

    public void GetHit(int damage)
    {
        if (_isdead) return;
        int health = Health - damage;

        if (health <= 0)
        {
            _isdead = true;
            _gameHealper.TakeBEP(BEP);
            if (_gameHealper.BossTimer.activeSelf == true)
            {
                _gameHealper.BossTimer.SetActive(false);
                _gameHealper.BossTimerTime = 15;
            }
            int random = UnityEngine.Random.Range(0, 100);
            if (random < CoinChanse)
            {
                _gameHealper.TakeCoin(1);
            }
            Destroy(gameObject);
            GameObject DeathEffectObj = Instantiate(DeathEffect) as GameObject;
            Destroy(DeathEffectObj, 2);
        }
        GetComponent<Animator>().SetBool("Is_Stay", false);
        GetComponent<Animator>().SetTrigger("Hit");
        Health = health;
        _gameHealper.HealthSlider.value = Health;
    }

    private IEnumerator Stage1()
    {
        once = true;
        while (Health < MaxHealth)
        {
            if (Health > Convert.ToInt32((MaxHealth / 100) * 90))
            {
                Health += Convert.ToInt32((MaxHealth / 100) * 1);
                yield return new WaitForSeconds(1);
            }
            if (Health > Convert.ToInt32((MaxHealth / 100) * 70))
            {
                Health += Convert.ToInt32((MaxHealth / 100) * 1);
                yield return new WaitForSeconds(0.7f);
            }
            if (Health <= Convert.ToInt32((MaxHealth / 100) * 70))
            {
                Health += Convert.ToInt32((MaxHealth / 100) * 2);
                yield return new WaitForSeconds(0.4f);
            }
            if (Health <= Convert.ToInt32((MaxHealth / 100) * 50))
            {
                Health += Convert.ToInt32((MaxHealth / 100) * 2);
                yield return new WaitForSeconds(0.5f);
            }
            if (Health <= Convert.ToInt32((MaxHealth / 100) * 30))
            {
                Health += Convert.ToInt32((MaxHealth / 100) * 3);
                yield return new WaitForSeconds(0.3f);
            }
            if (Health <= Convert.ToInt32((MaxHealth / 100) * 30))
            {
                Health += Convert.ToInt32((MaxHealth / 100) * 4);
                yield return new WaitForSeconds(0.1f);
            }
            if (Health == Convert.ToInt32((MaxHealth / 100) * 0))
            {
                Health = -1;
            }

            //Health += Convert.ToInt32((MaxHealth / 100) * 1);
            //yield return new WaitForSeconds(1);
        }
        once = false;

    }
    public IEnumerator BossTimerEnumerator()
    {
        oncefortimer = true;
        _gameHealper.BossTimer.SetActive(true);
        while (_gameHealper.BossTimerTime > 0)
        {
            _gameHealper.BossTimerTime -= 1;
            if (_gameHealper.BossTimerTime < 10)
            {
                _gameHealper.BossTimerText.text = _gameHealper.BossTimerTime.ToString("0");
            }
            else
            {
                _gameHealper.BossTimerText.text = _gameHealper.BossTimerTime.ToString("00");
            } 
            yield return new WaitForSeconds(1);
        }
        oncefortimer = false;
        _gameHealper.BossTimer.SetActive(false);
        Destroy(gameObject);
        _gameHealper.SpawnEnemy();
        _gameHealper.BossTimerTime = 15;

    }
    
}
