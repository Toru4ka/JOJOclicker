using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertHelper : MonoBehaviour
{

    private static ConvertHelper instance;
    public static ConvertHelper Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        CreateInstance();
    }

    void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public string GetCurrencyIntoString(float valueToConvert)
    {
        if (valueToConvert >= 1000000000000f) // trillion
        {
            valueToConvert = (valueToConvert / 1000000000000f);
            if (valueToConvert >= 100f) return valueToConvert.ToString("0") + "T";
            else if (valueToConvert >= 10f) return valueToConvert.ToString("0.0") + "T";
            else return valueToConvert.ToString("0.00") + "T";
        }
        else if (valueToConvert >= 1000000000f) // billions
        {
            valueToConvert = (valueToConvert / 1000000000f);
            if (valueToConvert >= 100f) return valueToConvert.ToString("0") + "B";
            else if (valueToConvert >= 10f) return valueToConvert.ToString("0.0") + "B";
            else return valueToConvert.ToString("0.00") + "B";
        }
        else if (valueToConvert >= 1000000f) // millions
        {
            valueToConvert = (valueToConvert / 1000000f);
            if (valueToConvert >= 100f) return valueToConvert.ToString("0") + "M";
            else if (valueToConvert >= 10f) return valueToConvert.ToString("0.0") + "M";
            else return valueToConvert.ToString("0.00") + "M";
        }
        else if (valueToConvert >= 1000) // thousands
        {
            valueToConvert = (valueToConvert / 1000f);
            if (valueToConvert >= 100f) return valueToConvert.ToString("0") + "K";
            else if (valueToConvert >= 10f) return valueToConvert.ToString("0.0") + "K";
            else return valueToConvert.ToString("0.00") + "K";
        }

        return valueToConvert.ToString();

    }

}

