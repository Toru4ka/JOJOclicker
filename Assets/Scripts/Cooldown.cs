using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Cooldown : MonoBehaviour
{
    public GameObject panelSkill;
    GameHelper _gameHelper;
    public Image kdImage;     
    public float cooldown = 1;
    public float cooldownTimer;
    void Start()
    {
       
        _gameHelper = GameHelper.FindObjectOfType<GameHelper>();
        kdImage.GetComponent<Image>();
    }
    public void Update()
    {
        if (cooldownTimer > 0 && kdImage.enabled == true)
        {
            
            cooldownTimer -= Time.deltaTime;
            float virtualcooldownTimer = cooldownTimer/ cooldown;
            kdImage.fillAmount = virtualcooldownTimer;
        }


        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;            
            kdImage.enabled = false;
        }

        if (cooldownTimer == 0 )
        {
            //bonus()
            
            cooldownTimer = cooldown;
        }  
    }

    public void SkillClick()
    {
        kdImage.enabled = true;
    }
    
}
