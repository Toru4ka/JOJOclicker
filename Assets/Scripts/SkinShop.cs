﻿using System;
using System.Collections;
using System.Collections.Generic;
using MonoBehaviours;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour
{
    GameHelper _gameHealper;
    PlayerHelper _playerHelper;
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    [SerializeField] private AnimatorOverrider overrider;

    [SerializeField] private int CurrentSkinIndex;
    public AudioClip CurrentBattleCry;
    [Header("Предметы магазина скинов")] public List<SkinItem> ShopSkinItems = new List<SkinItem>();
    [Header("Текст цен кнопок скинов")] public Text[] SkinPriseText;
    [Header("Кнопки магазина скинов")] public Button[] SkinshopButt;

    [HideInInspector] public Save svSkins = new Save();

    public void Awake()
    {
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        if (PlayerPrefs.HasKey("SVskins"))
        {
            svSkins = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SVskins"));
            CurrentSkinIndex = svSkins.CurrentSkinIndex;
            _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
            _playerHelper.SetCurrentBattleCry(ShopSkinItems[svSkins.CurrentSkinIndex].BattelCry);
            for (int i = 0; i < ShopSkinItems.Count; i++)
            {
                ShopSkinItems[i].Is_Have = svSkins.Is_Have[i];
            }
        }
    }

    void Start()
    {
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectSkin();
    }

    public void SkinByeButton(int index)
    {
        if (ShopSkinItems[index].Is_Have == false)
        {
            if (_gameHealper.PlayerCoin >= ShopSkinItems[index].coast) // buy success by coins
            {
                ShopSkinItems[index].Is_Have = true;
                _gameHealper.PlayerCoin -= ShopSkinItems[index].coast;
                CurrentSkinIndex = ShopSkinItems[index].SkinIndex;
            }
            else return;
        }
        else
        {
            CurrentSkinIndex = ShopSkinItems[index].SkinIndex;
            SelectSkin();
        }
    }

    public void checkSkinPrise()
    {
        for (int i = 0; i < ShopSkinItems.Count; i++)
        {
            if (ShopSkinItems[i].Is_Have == false)
            {
                SkinPriseText[i].text = ShopSkinItems[i].coast.ToString() + " Coin";
            }
            else
            {
                SkinPriseText[i].text = "";
            }
        }
    }

    public void SelectSkin()
    {
        for (int i = 0; i < ShopSkinItems.Count; i++)
        {
            if (i == CurrentSkinIndex && ShopSkinItems[i].Is_Have == true)
            {
                SkinPriseText[i].text = "Select";
                overrider.SetAnimations(overrideControllers[i]);
                CurrentBattleCry = ShopSkinItems[i].BattelCry;
                _playerHelper = FindObjectOfType<PlayerHelper>();
                _playerHelper.SetCurrentBattleCry(ShopSkinItems[i].BattelCry);
            }
            else
            {
                if (ShopSkinItems[i].Is_Have == false)
                {
                    SkinPriseText[i].text = ShopSkinItems[i].coast.ToString() + " Coin";
                }
                else
                {
                    SkinPriseText[i].text = "";
                }
            }
        }
    }


    [Serializable]
    public class SkinItem
    {
        public int coast;
        public bool Is_Have;
        public int SkinIndex;
        public AudioClip BattelCry;
    }

    public class Save
    {
        public bool[] Is_Have;
        public int CurrentSkinIndex;
    }

    public void SaveFuc()
    {
        svSkins.Is_Have = new bool[ShopSkinItems.Count];
        svSkins.CurrentSkinIndex = CurrentSkinIndex;
        for (int i = 0; i < ShopSkinItems.Count; i++)
        {
            svSkins.Is_Have[i] = ShopSkinItems[i].Is_Have;
        }

        PlayerPrefs.SetString("SVskins", JsonUtility.ToJson(svSkins));
        PlayerPrefs.Save();
        Debug.Log("Save");
    }

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

    private void OnApplicationQuit()
    {
        SaveFuc();
    }
}