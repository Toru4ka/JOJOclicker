using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityDisplay : MonoBehaviour
{

    public ability ability;
    public Button Ability_Button;
    public Image KD_Image;

    void Start()
    {
        Ability_Button.image.sprite = ability.ability_sprite;
        KD_Image.sprite = ability.kdImage;
    }

    public void Update()
    {
        if (ability.cooldownTimer > 0 && KD_Image.enabled == true)
        {

            ability.cooldownTimer -= Time.deltaTime;
            float virtualcooldownTimer = ability.cooldownTimer / ability.cooldown;
            KD_Image.fillAmount = virtualcooldownTimer;
        }


        if (ability.cooldownTimer < 0)
        {
            ability.cooldownTimer = 0;
            KD_Image.enabled = false;
        }

        if (ability.cooldownTimer == 0)
        {
            //bonus()

            ability.cooldownTimer = ability.cooldown;
        }
    }

    public void SkillClick()
    {
        KD_Image.enabled = true;
    }

}
