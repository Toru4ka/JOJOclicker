using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonHelper : MonoBehaviour
{
    public GameObject ButtonPlusHero;
    public GameObject HeroPrefab;

    public bool IsHeroUp;
    public bool IsCoin;
    public bool IsHero;

    private int Owner = 1;
    private int Price;
    public int Damage = 1;

    private float Multiplier = 1.15f;

    public Text DamageText;
    public Text PriceText;

    public double BaseCoast;
    public double PriceDoble;

    GameHelper _gameHealper;
    HeroHelper _heroHelper;

    void Start()
    {
        Price = (int)BaseCoast;
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();
        _heroHelper = GameObject.FindObjectOfType<HeroHelper>();

    }

    public void UpHero()
    {
        if (_gameHealper.PlayerCoin >= Price)
        {
            _gameHealper.PlayerCoin -= Price;

            _heroHelper.Damage += Damage;
            
            PriceDoble = BaseCoast * Mathf.Pow(Multiplier, Owner);
            Price = (int)PriceDoble;
            PriceText.text = Price.ToString();
            Owner++;          
        }
    }

    public void UpClick()
    {
        if (_gameHealper.PlayerBEP >= Price)
        {
            _gameHealper.PlayerBEP -= Price;
            _gameHealper.PlayerDamage += Damage;
           
            PriceDoble = BaseCoast * Mathf.Pow(Multiplier, Owner);
            Price = (int)PriceDoble;
            PriceText.text = Price.ToString();
            Owner++;           
        }
    }

    public void PlusHero()
    {

        if (_gameHealper.PlayerBEP >= Price || IsCoin && _gameHealper.PlayerCoin >= Price)
        {
            if (!IsCoin) _gameHealper.PlayerBEP -= Price;
            else _gameHealper.PlayerCoin -= Price;

        }
        if (IsHero == true)
        {
            GameObject hero = Instantiate(HeroPrefab) as GameObject;
            Destroy(ButtonPlusHero);
        }

    }
    
}
