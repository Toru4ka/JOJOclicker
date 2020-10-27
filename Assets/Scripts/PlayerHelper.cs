using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    

    void Start()
    {
        
    }


    void Update()
    {
       
    }

    public void Skin_ST3()
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
    }
    public void RunAttack()
    {
        GetComponent<Animator>().SetBool("is_stay", false);
        GetComponent<Animator>().SetTrigger("Attack");
    }

}






