using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHelper : MonoBehaviour
{
    public GameObject MeleeHero;
    public GameObject BulletPrefab;
    public int Damage = 10;
    public float AttackSpeed = 2.0f;
    HealthHelper _healthHelper;
    

    void Start()
    {
        _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {      
            yield return new WaitForSeconds(AttackSpeed);
            GameObject bullet = Instantiate(BulletPrefab) as GameObject;
            bullet.GetComponent<BulletHelper>().Damage = Damage;
            StartCoroutine(Attack());      
    }

    void Update()
    {
       
    }

    
}
