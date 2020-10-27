using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GHTEST : MonoBehaviour
{
    GameHelper _gameHealper;
    HeroHelper _heroHelper;
    public GameObject HeroPrefab;
    public Text[] PriseText;
    public Button[] shopButt;
    public List<Item> ShopItems = new List<Item>();
    private Save sv = new Save();
    public Text BEPText;
    const int Freeq = 3;
    public GameObject CoinPrefab;
    public Text DamageText;
    public Slider HealthSlider;
    public Transform StartPosition;
    public GameObject BEPPrefab;
    public GameObject[] EnemysPrefabs;
    public int PlayerBEP;
    public int PlayerCoin;
    public int PlayerDamage = 10;
    public GameObject[] target_2;
    public Text CoinText;
    int _count;
    int index;

    void Start()
    {

        if (PlayerPrefs.HasKey("COIN_SV") || PlayerPrefs.HasKey("BEP_SV") || PlayerPrefs.HasKey("Damage_SV"))
        {
            PlayerCoin = PlayerPrefs.GetInt("COIN_SV");
            PlayerBEP = PlayerPrefs.GetInt("BEP_SV");
            PlayerDamage = PlayerPrefs.GetInt("Damage_SV");
            index = PlayerPrefs.GetInt("index_SV", index);
            GameObject ememyObj = Instantiate(EnemysPrefabs[index]) as GameObject;
            ememyObj.transform.position = StartPosition.position;
        }
        else
        {
            SpawnEnemy();
        }
        for (int i = 0; i < ShopItems.Count; i++)
        {
            ShopItems[i].coast = ShopItems[i].basecoast;
        }

        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
            for (int i = 0; i < ShopItems.Count; i++)
            {
                ShopItems[i].owner = sv.lvl_owner[i];
                ShopItems[i].coast = sv.sv_coast[i];
            }
            for (int i = 0; i < ShopItems.Count; i++)
            {
                PriseText[i].text = ShopItems[i].coast.ToString();
            }
            _gameHealper.PlayerDamage = sv.damage;
        }
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        _heroHelper = GameObject.FindObjectOfType<HeroHelper>();
    }

    private void OnApplicationQuit()
    {
        sv.lvl_owner = new int[ShopItems.Count];
        sv.sv_coast = new int[ShopItems.Count];
        for (int i = 0; i < ShopItems.Count; i++)
        {
            sv.lvl_owner[i] = ShopItems[i].owner;
            sv.sv_coast[i] = ShopItems[i].coast;
        }
        sv.damage = _gameHealper.PlayerDamage;
        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
    }


    public void Buttonclikc(int index)
    {
        if (ShopItems[index].Is__Up_Player)
        {
            if (_gameHealper.PlayerBEP >= ShopItems[index].coast)
            {
                _gameHealper.PlayerDamage += ShopItems[index].damage;
                _gameHealper.PlayerBEP -= ShopItems[index].coast;
                PlayerPrefs.SetInt("Damage_SV", _gameHealper.PlayerDamage);
                ShopItems[index].doublecoast = ShopItems[index].basecoast * Mathf.Pow(ShopItems[index].Multiplier, ShopItems[index].owner);
                ShopItems[index].coast = (int)ShopItems[index].doublecoast;
                PriseText[index].text = ShopItems[index].coast.ToString() + " BEP";
                ShopItems[index].owner++;
            }
            else return;
        }

        else if (ShopItems[index].Is_Plus_Hero)
        {
            if (_gameHealper.PlayerCoin >= ShopItems[index].coast)
            {
                _gameHealper.PlayerCoin -= ShopItems[index].coast;
                GameObject hero = Instantiate(HeroPrefab) as GameObject;

            }
            else return;
        }

        else if (ShopItems[index].Is_Up_Hero)
        {
            if (_gameHealper.PlayerCoin >= ShopItems[index].coast)
            {
                _heroHelper.Damage += ShopItems[index].damage;
                _gameHealper.PlayerCoin -= ShopItems[index].coast;
                ShopItems[index].doublecoast = ShopItems[index].basecoast * Mathf.Pow(ShopItems[index].Multiplier, ShopItems[index].owner);
                ShopItems[index].coast = (int)ShopItems[index].doublecoast;
                PriseText[index].text = ShopItems[index].coast.ToString() + " Coin";
                ShopItems[index].owner++;
            }
            else return;
        }
    }


    [Serializable]
    public class Item
    {
        public string name;
        public int coast;
        public int basecoast;
        public double doublecoast;
        public int damage;
        public int owner = 1;
        public float Multiplier = 1.15f;
        public bool Is_Plus_Hero;
        public bool Is_Up_Hero;
        public bool Is__Up_Player;
    }

    [Serializable]
    public class Save
    {
        public int[] lvl_owner;
        public int[] sv_coast;
        public int damage;
        public int BEP;
        public int Coin;
        public int indexOfEnemy;

    }

    private void Update()
    {
        BEPText.text = PlayerBEP.ToString();
        DamageText.text = PlayerDamage.ToString();
        CoinText.text = PlayerCoin.ToString();
    }

    public void TakeCoin(int Coin)
    {
        PlayerCoin += Coin;
        PlayerPrefs.SetInt("COIN_SV", PlayerCoin);
        GameObject CoinObj = Instantiate(CoinPrefab) as GameObject;
        Destroy(CoinObj, 3);
    }

    public void TakeBEP(int BEP)
    {
        PlayerBEP += BEP;
        PlayerPrefs.SetInt("BEP_SV", PlayerBEP);
        GameObject BEPObj = Instantiate(BEPPrefab) as GameObject;
        Destroy(BEPObj, 1);
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        _count++;

        int randomMaxValue = _count / Freeq + 1;

        if (randomMaxValue >= EnemysPrefabs.Length)
            randomMaxValue = EnemysPrefabs.Length;
        int index = UnityEngine.Random.Range(0, randomMaxValue);
        PlayerPrefs.SetInt("index_SV", index);
        GameObject ememyObj = Instantiate(EnemysPrefabs[index]) as GameObject;
        ememyObj.transform.position = StartPosition.position;
    }

}
