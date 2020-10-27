using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Melee : MonoBehaviour
{
    
    GameObject Hero;
    HealthHelper _healthHelper;
    public int Damage = 10;
    public float time;

    void Start()
    {
        _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        
    }


    void Update()
    {
       
    }

    public void damag()
    {
        StartCoroutine(Attack());
        GetComponent<Animator>().SetTrigger("Attack");
    }


    IEnumerator Attack()
    {
        while (true)
        { 
            _healthHelper = GameObject.FindObjectOfType<HealthHelper>();           
            _healthHelper.GetHit(Damage);  
            yield return new WaitForSeconds(time);
            
        }
    }



}
