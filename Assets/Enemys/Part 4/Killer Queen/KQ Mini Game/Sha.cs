using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Sha : MonoBehaviour
{
    private MiniGame _miniGame;
    
    private void Start()
    {
        _miniGame = FindObjectOfType<MiniGame>();
    }
    private void Update()
    {
        //_miniGame = GetComponent<MiniGame>();    
    }
    public void DestroySHA()
    {
        _miniGame.Score += 1;
        Debug.Log("+1");
        Destroy(this.gameObject);
    }
    
}
