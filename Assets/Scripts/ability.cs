using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Ability", menuName = "Abilites")]
public class ability : ScriptableObject
{
    public new string name;

    public Sprite ability_sprite;

    public int attack;
    public Sprite kdImage;
    public float cooldown = 1;
    public float cooldownTimer;

    public float BonusTime;
    public float TimeOfBonus;
}
