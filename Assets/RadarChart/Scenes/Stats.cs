using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Stats
{
    public event EventHandler OnStatsChanged;
    
    public static int STAT_MIN = 0;
    public static int STAT_MAX = 6;
    
    public enum Type
    {
        DestructivePower,
        Speed,
        Range,
        Perseverance,
        Precision,
        DevelopmentPotential,
    }
    
    private SingleStat DestructivePowerStat;
    private SingleStat SpeedStat;
    private SingleStat RangeStat;
    private SingleStat PerseveranceStat;
    private SingleStat PrecisionStat;
    private SingleStat DevelopmentPotentialStat;
    
    public Stats(int DestructivePowerStatAmount, int SpeedStatAmount, int RangeStatAmount, int PerseveranceStatAmount, int PrecisionStatAmount, int DevelopmentPotentialStatAmount)
    {
        DestructivePowerStat = new SingleStat(DestructivePowerStatAmount);
        SpeedStat = new SingleStat(SpeedStatAmount);
        RangeStat = new SingleStat(RangeStatAmount);
        PerseveranceStat = new SingleStat(PerseveranceStatAmount);
        PrecisionStat = new SingleStat(PrecisionStatAmount);
        DevelopmentPotentialStat = new SingleStat(DevelopmentPotentialStatAmount);
    }

    private SingleStat getSingleStat(Type statType)
    {
        switch (statType)
        { 
            default:
            case Type.DestructivePower: return DestructivePowerStat;
            case Type.Speed: return SpeedStat;
            case Type.Range: return RangeStat;
            case Type.Perseverance: return PerseveranceStat;
            case Type.Precision: return PrecisionStat;
            case Type.DevelopmentPotential: return DevelopmentPotentialStat;
        }
    }

    public void SetStatAmount(Type statType, int statAmount)
    {
        getSingleStat(statType).SetStatAmount(statAmount);
        if(OnStatsChanged != null) OnStatsChanged (this, EventArgs.Empty);
    }

    public int GetStatAmount(Type statType)
    {
        return  getSingleStat(statType).GetStatAmount();
    }

    public float GetStatAmountNormalized(Type statType)
    {
        return getSingleStat(statType).GetStatAmountNormalized();
    }
    
    private class SingleStat
    {
        private int stat;

        public SingleStat(int statAmount)
        {
            SetStatAmount(statAmount);
        }
        
        public void SetStatAmount(int statAmount)
        {
            stat = Mathf.Clamp(statAmount, STAT_MIN, STAT_MAX);
            
        }

        public int GetStatAmount()
        {
            return stat;
        }

        public float GetStatAmountNormalized()
        {
            return (float) stat / STAT_MAX;
        }
    }
}
