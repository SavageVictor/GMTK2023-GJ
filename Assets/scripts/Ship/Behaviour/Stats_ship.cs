using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_ship : MonoBehaviour
{
    public float Max_Helth = 100;
    public float ship_fire_speed = 10;
    public int Blink_Culdown = 100;

    public float score = 0;

    public float helth;

    void Start()
    {
        score = 0;
        helth = Max_Helth;
    }

}
