using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    private SkinShop _skinShop;
    public GameObject AttackEffect;

    void Start()
    {
        _skinShop = GameObject.FindObjectOfType<SkinShop>();
    }


    void Update()
    {
        
    }

    /*public void Skin_ST3()
    {
        GetComponent<Animator>().Play("New State");
        GetComponent<Animator>().SetBool("ST3", true);
        GetComponent<Animator>().SetBool("ST4", false);
    }
    public void Skin_ST4()
    {
        GetComponent<Animator>().Play("New State");
        GetComponent<Animator>().SetBool("ST3", false);
        GetComponent<Animator>().SetBool("ST4", true);
    }*/
    public void RunAttack()
    {
        GetComponent<Animator>().SetBool("is_stay", false);
        GetComponent<Animator>().SetTrigger("Attack");
        SpawnAttackEffect();
    }

    public void SpawnAttackEffect()
    {
        GameObject AttackEffectObj = Instantiate(AttackEffect) as GameObject;
        HealthHelper Enemy = FindObjectOfType<HealthHelper>();
        AttackEffectObj.transform.position = Enemy.transform.position;
        Destroy(AttackEffectObj,0.2f);
        
    }
    
    public void SetIdel()
    {
        GetComponent<Animator>().SetBool("is_stay", true);
    }

    public void SetCurrentBattleCry(AudioClip BattleCry)
    {
        GetComponent<AudioSource>().clip = BattleCry;
    }

}






