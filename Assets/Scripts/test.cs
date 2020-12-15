using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class test : MonoBehaviour
{
    HealthHelper _healthHelper;
    GameHelper _gameHealper;
    HeroHelper _heroHelper;
    PlayerHelper _playerHelper;
    SMHelper sMHelper;

    public int i = 0;
    [Header("Эффекты")] public GameObject BPEEffectBye;
    [Header("Удаление кнопок")] public GameObject[] NeedToDelet;

    [Header("GameObject`s кнопок апгрейдов")]
    public GameObject[] UpGradesList;

    [Header("Текст цен кнопок")] public Text[] PriseText;
    [Header("Кнопки магазина")] public Button[] shopButt;
    [Header("Помощники")] public GameObject[] Herose;
    [Header("Предметы магазина")] public List<Item> ShopItems = new List<Item>();

    public GameObject Settings;

    public Save sv = new Save();
    public Sprite SpriteClouse;
    public Sprite unknowUpgrade;
    public Sprite Ramka;
    private int Damage = 10;
    private float time = 0.83f;

    public int GlobalSkinIndex;

    public bool HS0 = true;
    public bool HS1 = false;
    public bool HS2 = false;


    public void Awake()
    {
        _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        _heroHelper = GameObject.FindObjectOfType<HeroHelper>();
        _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
        sMHelper = GameObject.FindObjectOfType<SMHelper>();
        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
            for (int i = 0; i < ShopItems.Count; i++)
            {
                ShopItems[i].owner = sv.lvl_owner[i];
                ShopItems[i].coast = sv.sv_coast[i];
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < UpGradesList.Length; i++)
        {
            if (ShopItems[i].owner > 7)
            {
                if (i+1 < UpGradesList.Length)
                {
                    UpGradesList[i + 1].SetActive(true);
                }
                else
                {
                    return;
                }
            }
        }
    }

    void Start() // Load 
    {
        for (int i = 1; i < UpGradesList.Length; i++)
        {
            UpGradesList[i].SetActive(false);
        }

        //_healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        //_gameHealper = GameObject.FindObjectOfType<GameHelper>();
        //_heroHelper = GameObject.FindObjectOfType<HeroHelper>();
        //_playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
        //sMHelper = GameObject.FindObjectOfType<SMHelper>();

        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));

            _gameHealper.PlayerDamage = sv.damage;
            _gameHealper.PlayerBEP = sv.BEP;
            _gameHealper.PlayerCoin = sv.Coin;
            _gameHealper._count = sv._count;
            _gameHealper.index = sv.index;
            GlobalSkinIndex = sv.SkinIndex;
            HS0 = sv.HS0;
            HS1 = sv.HS1;
            if (PlayerPrefs.HasKey("SVMS"))
            {
                sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SVMS"));
                sMHelper.AMIsOn = sv.AMVolume;
                sMHelper.SliderSounds.value = sv.SoundVolume;
                sMHelper.SliderMusic.value = sv.MusicVolume;
            }

            sMHelper.AMIsOn = sv.AMVolume;
            sMHelper.SliderSounds.value = sv.SoundVolume;
            sMHelper.SliderMusic.value = sv.MusicVolume;


            GameObject ememyObj = Instantiate(_gameHealper.EnemysPrefabs[_gameHealper.index]) as GameObject;
            ememyObj.transform.position = _gameHealper.StartPosition.position;

            if (HS1 == true)
            {
                PriseText[8].text = "";
            }
            else
            {
                PriseText[8].text = "10 Coins";
            }


            for (int i = 0; i < ShopItems.Count; i++)
            {
                if (ShopItems[i].Is_Plus_Hero)
                {
                    PriseText[i].text = ShopItems[i].coast.ToString() + " Coin";
                }
                else if (ShopItems[i].Is_Skin)
                {
                    PriseText[i].text = ShopItems[i].coast.ToString() + " Coin";
                }
                else
                    //PriseText[i].text = ShopItems[i].coast.ToString() + " BEP";
                    PriseText[i].text = ConvertHelper.Instance.GetCurrencyIntoString(ShopItems[i].coast) + " BEP";
            }

            //_sMHelper.SliderMusic.value = sv.MusicVolume;
            //_sMHelper.SliderSounds.value = sv.SoundVolume;
            //checkSkinPrise();
        }
        else
        {
            if (PlayerPrefs.HasKey("SVMS"))
            {
                sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SVMS"));
                sMHelper.AMIsOn = sv.AMVolume;
                sMHelper.SliderSounds.value = sv.SoundVolume;
                sMHelper.SliderMusic.value = sv.MusicVolume;
            }

            _gameHealper.PlayerDamage = Damage;
            _gameHealper.SpawnEnemy();
            for (int i = 0; i < ShopItems.Count; i++)
            {
                ShopItems[i].coast = ShopItems[i].basecoast;
                if (ShopItems[i].Is_Plus_Hero)
                {
                    PriseText[i].text = ShopItems[i].coast.ToString() + " Coin";
                }

                else if (ShopItems[i].Is_Skin)
                {
                    PriseText[i].text = ShopItems[i].coast.ToString() + " Coin";
                }

                else
                    //PriseText[i].text = ShopItems[i].coast.ToString() + " BEP";
                    PriseText[i].text = ConvertHelper.Instance.GetCurrencyIntoString(ShopItems[i].coast) + " BEP";

                //checkSkinPrise();
            }
        }
    }

    /*public void checkSkinPrise()
    {
        PriseText[12].text = "";
        if (GlobalSkinIndex == 0)
        {
            _playerHelper.Skin_ST3();
            PriseText[12].text = "Selected";
            if (HS1 == true)
            {
                PriseText[8].text = "";
            }
            else
            {
                PriseText[13].text = "10 Coins";
            }
        }
        else if (GlobalSkinIndex == 1)
        {
            _playerHelper.Skin_ST4();
            PriseText[12].text = "";
            PriseText[13].text = "Selected";
        }
    }*/

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Debug.Log("Paused");
            //Save Player Settings
            SaveFuc();
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("resumed");
        }
    }

    private void OnApplicationQuit() //Save
    {
        sv.lvl_owner = new int[ShopItems.Count];
        sv.sv_coast = new Double[ShopItems.Count];
        for (int i = 0; i < ShopItems.Count; i++)
        {
            sv.lvl_owner[i] = ShopItems[i].owner;
            sv.sv_coast[i] = ShopItems[i].coast;
        }

        sv.damage = _gameHealper.PlayerDamage;
        sv.BEP = _gameHealper.PlayerBEP;
        sv.Coin = _gameHealper.PlayerCoin;
        sv._count = _gameHealper._count;
        sv.index = _gameHealper.index;
        sv.SkinIndex = GlobalSkinIndex;
        sv.HS0 = HS0;
        sv.HS1 = HS1;
        sv.AMVolume = sMHelper.AMIsOn;
        sv.SoundVolume = sMHelper.SliderSounds.value;
        sv.MusicVolume = sMHelper.SliderMusic.value;

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
        PlayerPrefs.Save();
    }

    public void Buttonclikc(int index)
    {
        if (ShopItems[index].Is__Up_Player)
        {
            if (_gameHealper.PlayerBEP >= ShopItems[index].coast) // buy success by BPE
            {
                _gameHealper.PlayerDamage += ShopItems[index].damage;
                _gameHealper.PlayerBEP -= ShopItems[index].coast;
                //PlayerPrefs.SetInt("Damage_SV", _gameHealper.PlayerDamage);
                ShopItems[index].doublecoast = ShopItems[index].basecoast *
                                               Mathf.Pow(ShopItems[index].Multiplier, ShopItems[index].owner);
                ShopItems[index].coast = ShopItems[index].doublecoast;
                //PriseText[index].text = ShopItems[index].coast.ToString() + " BEP";
                PriseText[index].text = ConvertHelper.Instance.GetCurrencyIntoString(ShopItems[index].coast) + " BEP";
                ShopItems[index].owner++;
                GameObject BPEEffectByeObj =
                    Instantiate(BPEEffectBye, shopButt[index].transform.position, Quaternion.identity) as GameObject;
                Destroy(BPEEffectByeObj, 3f);
            }
            else return;
        }

        else if (ShopItems[index].Is_Plus_Hero)
        {
            if (_gameHealper.PlayerCoin >= ShopItems[index].coast)
            {
                GameObject hero;
                switch (ShopItems[index].HeroNumber)
                {
                    case 0:
                        _gameHealper.PlayerCoin -= ShopItems[index].coast;
                        hero = Instantiate(Herose[ShopItems[index].HeroNumber]) as GameObject;
                        shopButt[index].image.sprite = SpriteClouse;
                        shopButt[index].interactable = false;
                        //Destroy(shopButt[index]);
                        break;
                    case 1:

                        _gameHealper.PlayerCoin -= ShopItems[index].coast;
                        hero = Instantiate(Herose[ShopItems[index].HeroNumber]) as GameObject;
                        StartCoroutine(Attack());
                        Destroy(shopButt[index]);
                        break;
                    default:
                        break;
                }

                //_gameHealper.PlayerCoin -= ShopItems[index].coast;
                //GameObject hero = Instantiate(HeroPrefab) as GameObject;
            }
            else return;
        }

        else if (ShopItems[index].Is_Up_Hero)
        {
            if (_gameHealper.PlayerCoin >= ShopItems[index].coast)
            {
                _heroHelper.Damage += ShopItems[index].damage;
                _gameHealper.PlayerCoin -= ShopItems[index].coast;
                ShopItems[index].doublecoast = ShopItems[index].basecoast *
                                               Mathf.Pow(ShopItems[index].Multiplier, ShopItems[index].owner);
                ShopItems[index].coast = ShopItems[index].doublecoast;
                PriseText[index].text = ShopItems[index].coast.ToString() + " Coin";
                ShopItems[index].owner++;
            }
            else return;
        }

        /*else if (ShopItems[index].Is_Skin)
        {
            if (ShopItems[index].SkinIndex == 0 && HS0 == true)
            {
                _playerHelper.Skin_ST3();
                GlobalSkinIndex = 0;
                PriseText[12].text = "Selected";
                if (HS1 == true)
                {
                    PriseText[13].text = "";
                }
                else
                {
                    PriseText[13].text = "10 Coins";
                }
            }

            else if (ShopItems[index].SkinIndex == 1 && HS1 == true)
            {
                _playerHelper.Skin_ST4();
                GlobalSkinIndex = 1;
                PriseText[12].text = "";
                PriseText[13].text = "Selected";
            }

            else if (_gameHealper.PlayerCoin >= ShopItems[index].coast)
            {
                _gameHealper.PlayerCoin -= ShopItems[index].coast;


                if (ShopItems[index].SkinIndex == 0)
                {
                    _playerHelper.Skin_ST3();
                    GlobalSkinIndex = 0;
                    HS0 = true;
                    PriseText[12].text = "Selected";
                    if (HS1 == true)
                    {
                        PriseText[13].text = "";
                    }
                    else
                    {
                        PriseText[13].text = "10 Coins";
                    }
                }

                else if (ShopItems[index].SkinIndex == 1)
                {
                    _playerHelper.Skin_ST4();
                    GlobalSkinIndex = 1;
                    HS1 = true;
                    PriseText[12].text = "";
                    PriseText[13].text = "Selected";
                    checkSkinPrise();
                }
            }
            else return;
        }*/

        SaveFuc();
        PlayerPrefs.Save();
    }

    [Serializable]
    public class Item
    {
        //[HideInInspector]
        public string ItemName;
        public double coast;
        public double basecoast;
        [HideInInspector] public double doublecoast;
        public int damage;
        public int owner = 1;
        public float Multiplier = 1.15f;
        public bool Is_Plus_Hero;
        public int HeroNumber;
        public bool Is_Up_Hero;
        public bool Is__Up_Player;

        public bool Is_Skin;
        public int SkinIndex;
    }

    [Serializable]
    public class Save
    {
        public int[] lvl_owner;
        public double[] sv_coast;

        public float multiplier;
        public int damage;
        public double BEP;
        public double Coin;
        public int _count;
        public int index;
        public int SkinIndex;
        public bool HS0;
        public bool HS1;
        public bool HS2;
        public bool AMVolume;
        public float SoundVolume;
        public float MusicVolume;
    }

    IEnumerator Attack()
    {
        while (true)
        {
            _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
            _healthHelper.GetHit(Damage);
            yield return new WaitForSeconds(time);
        }
    }

    //private void OnDisable() //Save
    //{
    //    sv.lvl_owner = new int[ShopItems.Count];
    //    sv.sv_coast = new int[ShopItems.Count];
    //    for (int i = 0; i < ShopItems.Count; i++)
    //    {
    //        sv.lvl_owner[i] = ShopItems[i].owner;
    //        sv.sv_coast[i] = ShopItems[i].coast;
    //    }
    //    sv.damage = _gameHealper.PlayerDamage;
    //    sv.BEP = _gameHealper.PlayerBEP;
    //    sv.Coin = _gameHealper.PlayerCoin;
    //    sv._count = _gameHealper._count;
    //    sv.index = _gameHealper.index;
    //    sv.SkinIndex = GlobalSkinIndex;
    //    sv.HS0 = HS0;
    //    sv.HS1 = HS1;
    //    sv.AMVolume = sMHelper.AMIsOn;
    //    sv.SoundVolume = sMHelper.SliderSounds.value;
    //    sv.MusicVolume = sMHelper.SliderMusic.value;
    //    PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
    //}

    public void SaveFuc()
    {
        sv.lvl_owner = new int[ShopItems.Count];
        sv.sv_coast = new Double[ShopItems.Count];

        for (int i = 0; i < ShopItems.Count; i++)
        {
            sv.lvl_owner[i] = ShopItems[i].owner;
            sv.sv_coast[i] = ShopItems[i].coast;
        }

        sv.multiplier = 1.15f;
        sv.damage = _gameHealper.PlayerDamage;
        sv.BEP = _gameHealper.PlayerBEP;
        sv.Coin = _gameHealper.PlayerCoin;
        sv._count = _gameHealper._count;
        sv.index = _gameHealper.index;
        sv.SkinIndex = GlobalSkinIndex;
        sv.HS0 = HS0;
        sv.HS1 = HS1;
        sv.AMVolume = sMHelper.AMIsOn;
        sv.SoundVolume = sMHelper.SliderSounds.value;
        sv.MusicVolume = sMHelper.SliderMusic.value;

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));

        PlayerPrefs.Save();

        Debug.Log("Save");
    }
}