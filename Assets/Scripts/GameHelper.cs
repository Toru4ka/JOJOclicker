﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Advertisements;

public class GameHelper : MonoBehaviour
{
    HealthHelper _healthHelper;
    public Text BEPText;
    const int Freeq = 3;

    public GameObject CoinPrefab;
    public Text DamageText;
    public Slider HealthSlider;
    public Transform StartPosition;
    public GameObject BEPPrefab;
    public GameObject[] EnemysPrefabs;
    public float PlayerBEP;
    public int PlayerCoin;
    public int PlayerDamage = 10;
    public GameObject[] target_2;
    public Text CoinText;
    public int _count;
    public int index;
    Vector3Int Position;

    public GameObject BossTimer;
    public Text BossTimerText;
    public float BossTimerTime;

    string GameIDPlayMarket = "3790483";
    string GameIDAppStore = "3790483";
    string VideoAdvertisements = "video";


    private void Start()
    {


        Advertisement.Initialize(GameIDPlayMarket, false);




        /*if (PlayerPrefs.HasKey("SV"))
        {
            PlayerCoin = PlayerPrefs.GetInt("COIN_SV");
            PlayerBEP = PlayerPrefs.GetInt("BEP_SV");
            PlayerDamage = PlayerPrefs.GetInt("Damage_SV");
            if (PlayerPrefs.HasKey("index_SV"))
            {
                index = PlayerPrefs.GetInt("index_SV", index);
                GameObject ememyObj = Instantiate(EnemysPrefabs[index]) as GameObject;
                ememyObj.transform.position = StartPosition.position;
            }

        }*/

    }


    private void Update()
    {
        //BEPText.text = PlayerBEP.ToString();
        BEPText.text = ConvertHelper.Instance.GetCurrencyIntoString(PlayerBEP);
        //DamageText.text = PlayerDamage.ToString();
        DamageText.text = ConvertHelper.Instance.GetCurrencyIntoString(PlayerDamage);
        CoinText.text = PlayerCoin.ToString();
    }

    public void TakeCoin(int Coin)
    {
        PlayerCoin += Coin;
        //PlayerPrefs.SetInt("COIN_SV", PlayerCoin);
        GameObject CoinObj = Instantiate(CoinPrefab) as GameObject;
        Destroy(CoinObj, 3);
    }

    public void TakeBEP(int BEP)
    {
        PlayerBEP += System.Convert.ToInt32(BEP * (_count * 0.25));
        //PlayerPrefs.SetInt("BEP_SV", PlayerBEP);
        GameObject BEPObj = Instantiate(BEPPrefab) as GameObject;
        Destroy(BEPObj, 1);
        SpawnEnemy();
    }



    public void SpawnEnemy()
    {
        float TempCount = _count;
        if ((TempCount % 50)==0)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
        }
            _count++;

        int randomMaxValue = _count / Freeq + 1;

        if (randomMaxValue >= EnemysPrefabs.Length)
            randomMaxValue = EnemysPrefabs.Length;
        index = UnityEngine.Random.Range(0, randomMaxValue);
        //PlayerPrefs.SetInt("index_SV", index);
        GameObject ememyObj = Instantiate(EnemysPrefabs[index]) as GameObject;
        ememyObj.transform.position = StartPosition.position;


    }




}
