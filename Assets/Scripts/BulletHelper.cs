using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHelper : MonoBehaviour
{
    public int Damage { get; set; }
    HealthHelper _healthHelper;

    void Start()
    {
        _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
    }


    void Update()
    {
        if (_healthHelper == null)
            _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _healthHelper.transform.position, Time.deltaTime * 30);
        }
        if (_healthHelper == null)
            return;
        if (Vector2.Distance(transform.position, _healthHelper.transform.position) < 1f)
        {
            _healthHelper.GetHit(Damage);
            Destroy(gameObject);
        }
    }
}
