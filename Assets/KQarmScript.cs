using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KQarmScript : MonoBehaviour
{
    private HealthHelper _healthHelper;
    void Start()
    {
        _healthHelper = FindObjectOfType<HealthHelper>();
    }

    public void ActivateKillerQueenMiniGameLose()
    {
        _healthHelper.KillerQueenMiniGameLose();
    }
}
