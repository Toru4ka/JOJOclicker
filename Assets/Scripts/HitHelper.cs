using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour
{
    GameHelper _gameHealper;
    PlayerHelper _playerHelper;
    StoreHelper _storeHelper;



    void Start()
    {
        _gameHealper = GameObject.FindObjectOfType<GameHelper>();
        _playerHelper = GameObject.FindObjectOfType<PlayerHelper>();
        _storeHelper = GameObject.FindObjectOfType<StoreHelper>();
        
    }


    void Update()
    {

    }

    void OnMouseDown()
    {
        if (_storeHelper.netydarov == true) return;
        GetComponent<HealthHelper>().GetHit(_gameHealper.PlayerDamage);
        _playerHelper.RunAttack();
    }

}
