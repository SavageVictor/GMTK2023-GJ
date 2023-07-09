using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats_ship : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;

    public float Max_Helth = 100;
    public float ship_fire_speed = 10;
    public float reloding_time = 2;
    public int Blink_Culdown = 100;
    public int BulletCount = 20;

    public float score = 0;

    public float helth;

    void Start()
    {
        score = 0;
        helth = Max_Helth;
        ScoreUpdate(0);
    }

    void ScoreUpdate(int addToScore)
    {
        score += addToScore;
        scoreUI.text = score.ToString("0");
    }

}
