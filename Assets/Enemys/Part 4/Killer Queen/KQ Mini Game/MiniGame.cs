using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MiniGame : MonoBehaviour
{
    private MiniGame _miniGame;
    public Transform[] SpawnPositionTarget;
    public int Score;
    public Text ScoreText;
    public GameObject SHAPrefab;
    public GameObject PanelMinigame;
    [SerializeField] public bool once = false;
    private bool OnceOnTime = false;
    private HealthHelper _healthHelper;
    private HitHelper _hitHelper;
    private Coroutine MiniGameCoroutine;
    private Coroutine MiniGameCoroutinehelp;
    [SerializeField]private GameObject Explosion;
    private Transform LastPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        _healthHelper = FindObjectOfType<HealthHelper>();
        _hitHelper = FindObjectOfType<HitHelper>();
        if (!once && _healthHelper.IS_Boss_Part4)
        {
            StartMiniGame();
        }
        ScoreText.text = Score.ToString();
    }

    private IEnumerator KillerQeenMiniGame()
    {
        once = true;
        _hitHelper.nohit = true;
        int i = 0;
        while (i < 10)
        {
            Transform transformSHAObj = SpawnPositionTarget[Random.Range(0, 15)];
            GameObject SHAObj = Instantiate(SHAPrefab, transformSHAObj.position, Quaternion.identity);
            SHAObj.transform.SetParent(GameObject.FindGameObjectWithTag("PanelMinigameKQ").transform);
            LastPosition = SHAObj.transform;
            Invoke("makeExplosion",0.53f);
            Destroy(SHAObj, 0.53f);
            yield return new WaitForSeconds(0.53f);
            i++;
            if (i > 8)
            {
                if (Score != 0)
                {
                    _healthHelper.Health -= (_healthHelper.Health * (Score * 10)) / 100;
                }
                Score = 0;
                ScoreText.text = Score.ToString();
                StopCoroutine(MiniGameCoroutine);
                PanelMinigame.SetActive(false);
            }
        }
    }

    public void StartMiniGame()
    {
        PanelMinigame.SetActive(true);
        MiniGameCoroutine = StartCoroutine(KillerQeenMiniGame());
        MiniGameCoroutinehelp = StartCoroutine(KillerQeen());
    }

    private IEnumerator KillerQeen()
    {
        float t = 0;
        while (t < 10)
        {
            yield return new WaitForSeconds(0.53f);
            t++;
        }
        StopCoroutine(MiniGameCoroutinehelp);
        _hitHelper.nohit = false;
    }

    private void makeExplosion()
    {
        GameObject ExplosionObj = Instantiate(Explosion, LastPosition.transform.position, Quaternion.identity);
    }
}