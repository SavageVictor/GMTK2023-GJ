using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.PlayerLoop.EarlyUpdate;

public class Stats_ship : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    public GameStateS _state;

    public float Max_Helth = 100;
    public float ship_fire_speed = 10;
    public float reloding_time = 2;
    public int Blink_Culdown = 100;
    public int BulletCount = 20;

    public float score = 0;

    public float helth;

    public float _timeer = 1;
    public float _time;

    void Start()
    {
        score = 0;
        helth = Max_Helth;
        ScoreUpdate(0);
    }

    void Update()
    {
        if (_state.GameIsStart && !_state.GameIsPause)
        {
            if (_time <= 0)
            {
                ScoreUpdate(1);
                _time = _timeer;
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }
    }

    public void ScoreUpdate(int addToScore)
    {
        score += addToScore;
        scoreUI.text = score.ToString("0");
    }


/*
    public void ScoreMin(int addToScore)
    {
        score -= addToScore;
        scoreUI.text = score.ToString("0");
    }*/

}
