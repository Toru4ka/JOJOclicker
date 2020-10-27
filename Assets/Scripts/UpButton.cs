using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpButton : MonoBehaviour
{

    GameHelper _gameHealper;
    HeroHelper _heroHelper;
    public GameObject HeroPrefab;
    public GameObject HeroButt;
    public Text[] PriseText;
    public double[] DoublePrice;
    public int[] Price;
    public int[] BaseCoast;
    public int[] Damage;
    private int Owner = 1;
    private float Multiplier = 1.15f;




    void Start()
    {
        for (int i = 0; i < BaseCoast.Length; i++)
        {
            Price[i] = BaseCoast[i];
        }

        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        _heroHelper = GameObject.FindObjectOfType<HeroHelper>();
    }

    private void OnApplicationQuit()
    {

    }

    void Update()
    {

    }

    public void Buttn_addBonus_Player(int index)
    {
        if (_gameHealper.PlayerBEP >= Price[index])
        {
            _gameHealper.PlayerDamage += Damage[index];
            _gameHealper.PlayerBEP -= Price[index];
            PlayerPrefs.SetInt("Damage_SV", _gameHealper.PlayerDamage);
            DoublePrice[index] = BaseCoast[index] * Mathf.Pow(Multiplier, Owner);
            Price[index] = (int)DoublePrice[index];
            PriseText[index].text = Price[index].ToString() + " BEP";
            Owner++;
        }
        else
        {
            return;
        }

    }

    public void PlusHero(int index)
    {

        if (_gameHealper.PlayerCoin >= Price[index])
        {
            _gameHealper.PlayerCoin -= Price[index];
            GameObject hero = Instantiate(HeroPrefab) as GameObject;
            Destroy(HeroButt);

        }
    }

    public void Buttn_addBonus_Hero(int index)
    {
        if (_gameHealper.PlayerCoin >= Price[index])
        {
            _heroHelper.Damage += Damage[index];
            _gameHealper.PlayerBEP -= Price[index];
            DoublePrice[index] = BaseCoast[index] * Mathf.Pow(Multiplier, Owner);
            Price[index] = (int)DoublePrice[index];
            PriseText[index].text = Price[index].ToString() + " Coin";
            Owner++;
        }
        else
        {
            return;
        }
    }

    [Serializable]
    public class Item
    {
        public string name;
        public int coast;
        public int damage;
        public int owner;
        public bool Is_Plus_Hero;
        public bool Is_Up_Hero;
        public bool Is__Up_Player;
    }


}
