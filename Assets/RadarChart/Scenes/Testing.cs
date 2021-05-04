using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    [SerializeField] private UI_StatRadarChart uiStatRadarChart;
    [SerializeField] private GameHelper gameHelper;

    private int StartpointDestructivePower = 200;
    private int StartpointSpeed;
    private double StartpointRange = 10000;
    private int StartpointPerseverance = 50;
    private int StartpointPrecision = 10;
    private int StartpointDevelopmentPotential = 5;
    
    [Range(0, 6)] public int DestructivePower;
    [Range(0, 6)] public int Speed;
    [Range(0, 6)] public int Range;
    [Range(0, 6)] public int Perseverance;
    [Range(0, 6)] public int Precision;
    [Range(0, 6)] public int DevelopmentPotential;

    public Text DestructivePowerLVL; //Damage
    public Text SpeedLVL; //Attack Speed (помощника)
    public Text RangeLVL; // количество BPE
    public Text PerseveranceLVL; //Количество побед над стендами
    public Text PrecisionLVL; //количество монет
    public Text DevelopmentPotentialLVL; //количество убитых босов или купленных улучшений

    public Text DestructivePowerText;
    public Text SpeedText;
    public Text RangeText;
    public Text PerseveranceText;
    public Text PrecisionText;
    public Text DevelopmentPotentialText;

    public Text DestructivePowerTextProgress;
    public Text SpeedTextProgress;
    public Text RangeTextProgress;
    public Text PerseveranceTextProgress;
    public Text PrecisionTextProgress;
    public Text DevelopmentPotentialTextProgress;

    private void Start()
    {
       statCheckint("Destructive power", "damage", true, gameHelper.PlayerDamage, 0, StartpointDestructivePower, 0, DestructivePower, DestructivePowerText, DestructivePowerLVL,DestructivePowerTextProgress);
       //statCheckint("Speed",);
       statCheckint("Range", "BPE", false, 0, gameHelper.recordPlayerBEP, 0, StartpointRange, Range, RangeText, RangeLVL,RangeTextProgress);
       statCheckint("Perseverance","enemies defeated",true,gameHelper._count,0,StartpointPerseverance,0,Perseverance,PerseveranceText,PerseveranceLVL,PerseveranceTextProgress);
       statCheckint("Precision","coins",false,0,gameHelper.recordPlayerCoin,0,StartpointPrecision,Precision,PrecisionText,PrecisionLVL,PrecisionTextProgress);
       statCheckint("DevelopmentPotential","defeated bosses",true,gameHelper._countDefeatedBosses,0,StartpointDevelopmentPotential,0,DevelopmentPotential,DevelopmentPotentialText,DevelopmentPotentialLVL,DevelopmentPotentialTextProgress);
       Stats stats = new Stats(DestructivePower, Speed, Range, Perseverance, Precision, DevelopmentPotential);
       uiStatRadarChart.SetStats(stats);
    }

    private void Update()
    {
        statCheckint("Destructive power", "damage", true, gameHelper.PlayerDamage, 0, StartpointDestructivePower, 0, DestructivePower, DestructivePowerText, DestructivePowerLVL,DestructivePowerTextProgress);
        //statCheckint("Speed",);
        statCheckint("Range", "BPE", false, 0, gameHelper.recordPlayerBEP, 0, StartpointRange, Range, RangeText, RangeLVL,RangeTextProgress);
        statCheckint("Perseverance","enemies defeated",true,gameHelper._count,0,StartpointPerseverance,0,Perseverance,PerseveranceText,PerseveranceLVL,PerseveranceTextProgress);
        statCheckint("Precision","coins",false,0,gameHelper.recordPlayerCoin,0,StartpointPrecision,Precision,PrecisionText,PrecisionLVL,PrecisionTextProgress);
        statCheckint("DevelopmentPotential","defeated bosses",true,gameHelper._countDefeatedBosses,0,StartpointDevelopmentPotential,0,DevelopmentPotential,DevelopmentPotentialText,DevelopmentPotentialLVL,DevelopmentPotentialTextProgress);
        Stats stats = new Stats(DestructivePower, Speed, Range, Perseverance, Precision, DevelopmentPotential);
        uiStatRadarChart.SetStats(stats);
    }
    public void statCheckint(string NameStat, string Unit, bool intOrduable, int playerstatOnCheckINT, double playerstatOnCheckDOUBLE, int startpointStatINT, double startpointStatDOUBLE, int currentStat, Text textStat, Text textStatLVL,Text textStatProgress)
    {
        if (intOrduable == false)
        {
            if (playerstatOnCheckDOUBLE >= startpointStatDOUBLE)
            {
                currentStat = 1;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                textStatLVL.text = "E";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatDOUBLE * 5 + " " + Unit + "";
                textStatProgress.text = ConvertHelper.Instance.GetCurrencyIntoString(playerstatOnCheckDOUBLE) + "/" + ConvertHelper.Instance.GetCurrencyIntoString(startpointStatDOUBLE * 5);
            }

            if (playerstatOnCheckDOUBLE >= startpointStatDOUBLE * 5)
            {
                currentStat = 2;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "D";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatDOUBLE * 5 * 5 + " " + Unit + "";
                textStatProgress.text = ConvertHelper.Instance.GetCurrencyIntoString(playerstatOnCheckDOUBLE) + "/" + ConvertHelper.Instance.GetCurrencyIntoString(startpointStatDOUBLE * 5 * 5);
            }

            if (playerstatOnCheckDOUBLE >= startpointStatDOUBLE * 5 * 5)
            {
                currentStat = 3;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                textStatLVL.text = "C";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatDOUBLE * 5 * 5 * 5 + " " + Unit + "";
                textStatProgress.text = ConvertHelper.Instance.GetCurrencyIntoString(playerstatOnCheckDOUBLE) + "/" + ConvertHelper.Instance.GetCurrencyIntoString(startpointStatDOUBLE * 5 * 5 * 5);
            }

            if (playerstatOnCheckDOUBLE >= startpointStatDOUBLE * 5 * 5 * 5)
            {
                currentStat = 4;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "B";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatDOUBLE * 5 * 5 * 5 * 5 + " " + Unit + "";
                textStatProgress.text = ConvertHelper.Instance.GetCurrencyIntoString(playerstatOnCheckDOUBLE) + "/" + ConvertHelper.Instance.GetCurrencyIntoString(startpointStatDOUBLE * 5 * 5 * 5 * 5);
            }

            if (playerstatOnCheckDOUBLE >= startpointStatDOUBLE * 5 * 5 * 5 * 5)
            { 
                currentStat = 5;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "A";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatDOUBLE * 5 * 5 * 5 * 5 * 5 + " " + Unit + "";
                textStatProgress.text = ConvertHelper.Instance.GetCurrencyIntoString(playerstatOnCheckDOUBLE) + "/" + ConvertHelper.Instance.GetCurrencyIntoString(startpointStatDOUBLE * 5 * 5 * 5 * 5 * 5);
            }

            if (playerstatOnCheckDOUBLE >= startpointStatDOUBLE * 5 * 5 * 5 * 5 * 5)
            {
                currentStat = 6;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "∞";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatDOUBLE * 5 * 5 * 5 * 5 * 5 * 5 + " " + Unit + "";
                textStatProgress.text = ConvertHelper.Instance.GetCurrencyIntoString(playerstatOnCheckDOUBLE) + "/" + ConvertHelper.Instance.GetCurrencyIntoString(startpointStatDOUBLE * 5 * 5 * 5 * 5 * 5 * 5);
            }

            if (playerstatOnCheckDOUBLE < startpointStatDOUBLE)
            {
                currentStat = 0;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "?";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatDOUBLE + " " + Unit + "";
                textStatProgress.text = ConvertHelper.Instance.GetCurrencyIntoString(playerstatOnCheckDOUBLE) + "/" + ConvertHelper.Instance.GetCurrencyIntoString(startpointStatDOUBLE);
            }
        }
        else
        {
            if (playerstatOnCheckINT >= startpointStatINT)
            {
                currentStat = 1;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "E";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatINT * 5 + " " + Unit + "";
                textStatProgress.text = playerstatOnCheckINT + "/" + startpointStatINT * 5;
            }

            if (playerstatOnCheckINT >= startpointStatINT * 5)
            {
                currentStat = 2;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "D";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatINT * 5 * 5 + " " + Unit + "";
                textStatProgress.text = playerstatOnCheckINT + "/" + startpointStatINT * 5 * 5;
            }

            if (playerstatOnCheckINT >= startpointStatINT * 5 * 5)
            {
                currentStat = 3;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "C";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatINT * 5 * 5 * 5 + " " + Unit + "";
                textStatProgress.text = playerstatOnCheckINT + "/" + startpointStatINT * 5 * 5 * 5;
            }

            if (playerstatOnCheckINT >= startpointStatINT * 5 * 5 * 5)
            {
                currentStat = 4;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "B";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatINT * 5 * 5 * 5 * 5 + " " + Unit + "";
                textStatProgress.text = playerstatOnCheckINT + "/" + startpointStatINT * 5 * 5 * 5 * 5;
            }

            if (playerstatOnCheckINT >= startpointStatINT * 5 * 5 * 5 * 5)
            {
                currentStat = 5;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "A";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatINT * 5 * 5 * 5 * 5 * 5 + " " + Unit + "";
                textStatProgress.text = playerstatOnCheckINT + "/" + startpointStatINT * 5 * 5 * 5 * 5 * 5;

            }

            if (playerstatOnCheckINT >= startpointStatINT * 5 * 5 * 5 * 5 * 5)
            {
                currentStat = 6;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "∞";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatINT * 5 * 5 * 5 * 5 * 5 * 5 + " " + Unit + "";
                textStatProgress.text = playerstatOnCheckINT + "/" + startpointStatINT * 5 * 5 * 5 * 5 * 5 * 5;
            }

            if (playerstatOnCheckINT < startpointStatINT)
            {
                currentStat = 0;
                if (NameStat == "Destructive power") DestructivePower = currentStat;
                if (NameStat == "Speed") Speed = currentStat;
                if (NameStat == "Range") Range = currentStat;
                if (NameStat == "Perseverance") Perseverance = currentStat;
                if (NameStat == "Precision") Precision = currentStat;
                if (NameStat == "DevelopmentPotential") DevelopmentPotential = currentStat;
                
                textStatLVL.text = "?";
                textStat.text = "" + NameStat + " " + textStatLVL.text + " to next LVL you need " + startpointStatINT + " " + Unit + "";
                textStatProgress.text = playerstatOnCheckINT + "/" + startpointStatINT;
            }
        }
        //return (currentStat);
        Stats stats = new Stats(DestructivePower, Speed, Range, Perseverance, Precision, DevelopmentPotential);
        uiStatRadarChart.SetStats(stats); 
    }
}